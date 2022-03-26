using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Query
{
    public class GetMealsByUserQueryHandler : IRequestHandler<GetMealsByUserQuery, List<MealDTO>>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsByUserQueryHandler(
            IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }
        public async Task<List<MealDTO>> Handle(GetMealsByUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _mealRepository.GetMealsByUser(request.UserId);
            if (request.Type != null)
            {
                result = result.Where(a => a.TypeOfMeal == request.Type).OrderBy(a=>a.MealName).ToList();
            }
            var dto = result.Select(a=> MealDTO.CreateFromEntity(a)).ToList();
            return dto;
        }
    }
}
