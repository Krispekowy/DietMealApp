using AutoMapper;
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
    public sealed class GetMealsByTypeQueryHandler : IRequestHandler<GetMealsByTypeQuery, SelectList>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsByTypeQueryHandler(
            IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<SelectList> Handle(GetMealsByTypeQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsByType(request.UserId, request.Type);
            return new SelectList(meals, "Id", "MealName");
        }
    }
}
