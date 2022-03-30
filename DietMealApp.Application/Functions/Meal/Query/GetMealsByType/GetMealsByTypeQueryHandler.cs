using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Query.GetMealsByType
{
    public sealed class GetMealsByTypeQueryHandler : BaseRequestHandler<GetMealsByTypeQuery, SelectList>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsByTypeQueryHandler(
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _mealRepository = mealRepository;
        }

        public override async Task<SelectList> Handle(GetMealsByTypeQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsByType(request.UserId, request.Type);
            return new SelectList(meals, "Id", "MealName");
        }
    }
}
