using AutoMapper;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.Interfaces;
using DietMealApp.Service.Functions.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Command.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;
        private readonly IMediator _mediator;
        private readonly IFileManager _fileManager;

        public UpdateMealCommandHandler(
            IMapper mapper,
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
            _mediator = mediator;
            _fileManager = fileManager;
        }

        public async Task<Unit> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            if (request.MealForm.Photo != null)
            {
                (request.MealForm.PhotoFullPath, request.MealForm.Photo150x150Path) = await _fileManager.SendFileToFtp(request.MealForm.Photo, Core.Enums.ImageType.Meal);
            }
            ClearValues(request);
            await CalculateNutritionalValues(request);
            var meal = _mapper.Map<Core.Entities.Meal>(request.MealForm);
            _mealRepository.Update(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }

        private static void ClearValues(UpdateMealCommand request)
        {
            request.MealForm.Kcal = request.MealForm.Protein = request.MealForm.Fats = request.MealForm.Carbohydrates = 0;
        }

        private async Task CalculateNutritionalValues(UpdateMealCommand request)
        {
            foreach (var product in request.MealForm.MealProducts)
            {
                var p = await _mediator.Send(new GetProductByIdQuery() { Id = product.ProductId });
                request.MealForm.Kcal = p.Kcal * Decimal.Divide(product.Quantity, 100) + request.MealForm.Kcal;
                request.MealForm.Protein = p.Protein * Decimal.Divide(product.Quantity, 100) + request.MealForm.Protein;
                request.MealForm.Fats = p.Fats * Decimal.Divide(product.Quantity, 100) + request.MealForm.Fats;
                request.MealForm.Carbohydrates = p.Carbohydrates * Decimal.Divide(product.Quantity, 100) + request.MealForm.Carbohydrates;
            }
        }
    }
}
