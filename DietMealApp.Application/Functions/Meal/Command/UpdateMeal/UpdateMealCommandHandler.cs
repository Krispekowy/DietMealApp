﻿using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
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
    public class UpdateMealCommandHandler : BaseRequestHandler<UpdateMealCommand, Unit>
    {
        private readonly IMealRepository _mealRepository;

        public UpdateMealCommandHandler(
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _mealRepository = mealRepository;
        }

        public override async Task<Unit> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            if (request.MealForm.Photo != null)
            {
                (request.MealForm.PhotoFullPath, request.MealForm.Photo150x150Path) = await _fileManager.SendFileToFtp(request.MealForm.Photo, Core.Enums.ImageType.Meal);
            }
            var meal = Core.Entities.Meal.CreateFromDto(request.MealForm);
            _mealRepository.Update(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
