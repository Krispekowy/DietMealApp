using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
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
    public sealed class GetMealsBySearchQueryHandler : BaseRequestHandler<GetMealsBySearchQuery, SelectList>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsBySearchQueryHandler(
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _mealRepository = mealRepository;
        }

        public override async Task<SelectList> Handle(GetMealsBySearchQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsByQuery(request.UserId, request.Query);
            return new SelectList(meals, "Id", "MealName");
        }
    }
}
