using AutoMapper;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Query.GetMealsBySearch
{
    public sealed class GetMealsBySearchQueryHandler : IRequestHandler<GetMealsBySearchQuery, SelectList>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsBySearchQueryHandler
            (
            IMealRepository mealRepository
            )
        {
            _mealRepository = mealRepository;
        }

        public async Task<SelectList> Handle(GetMealsBySearchQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsByQuery(request.UserId, request.Query);
            return new SelectList(meals, "Id", "MealName");
        }
    }
}
