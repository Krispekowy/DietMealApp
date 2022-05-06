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
using DietMealApp.Application.Commons.Abstract;

namespace DietMealApp.Application.Functions.Meal.Command.InsertMeal
{
    public class InsertMealCommandHandler : BaseRequestHandler<InsertMealCommand, Unit>
    {
        private readonly IMealRepository _mealRepository;

        public InsertMealCommandHandler(
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _mealRepository = mealRepository;
        }

        public override async Task<Unit> Handle(InsertMealCommand request, CancellationToken cancellationToken)
        {
            if (request.MealForm.Photo != null)
            {
                (request.MealForm.PhotoFullPath, request.MealForm.Photo150x150Path) = await _fileManager.SendFileToFtp(request.MealForm.Photo, Core.Enums.ImageType.Meal);
            }
            if (request.MealForm.MealProducts != null)
            {
                request.MealForm.MealProducts.RemoveAll(item => item.ProductId == Guid.Empty);
            }
            var meal = DietMealApp.Core.Entities.Meal.CreateFromDto(request.MealForm);
            _mealRepository.Insert(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
