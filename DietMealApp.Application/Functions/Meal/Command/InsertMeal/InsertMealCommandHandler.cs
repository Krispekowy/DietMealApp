using AutoMapper;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DietMealApp.Core.Entities;
using DietMealApp.Service.Functions.Query;
using DietMealApp.Application.Commons.Services.FileManager;

namespace DietMealApp.Application.Functions.Meal.Command.InsertMeal
{
    public class InsertMealCommandHandler : IRequestHandler<InsertMealCommand, Unit>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IFileManager _fileManager;

        public InsertMealCommandHandler(
            IMealRepository mealRepository,
            IMapper mapper,
            IMediator mediator,
            IFileManager fileManager
            )
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _mediator = mediator;
            _fileManager = fileManager;
        }

        public async Task<Unit> Handle(InsertMealCommand request, CancellationToken cancellationToken)
        {
            if (request.MealForm.Photo != null)
            {
                (request.MealForm.PhotoFullPath, request.MealForm.Photo150x150Path) = await _fileManager.SendFileToFtp(request.MealForm.Photo, Core.Enums.ImageType.Meal);
            }
            request.MealForm.MealProducts.RemoveAll(item => item.ProductId == Guid.Empty);
            var meal = _mapper.Map<DietMealApp.Core.Entities.Meal>(request.MealForm);
            _mealRepository.Insert(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
