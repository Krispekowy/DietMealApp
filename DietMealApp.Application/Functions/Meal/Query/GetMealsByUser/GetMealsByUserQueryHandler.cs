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
        private readonly IMapper _mapper;

        public GetMealsByUserQueryHandler(
            IMealRepository mealRepository,
            IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<List<MealDTO>> Handle(GetMealsByUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _mealRepository.GetMealsByUser(request.UserId);
            if (request.Type != null)
            {
                result = result.Where(a => a.TypeOfMeal == request.Type).ToList();
            }
            var ordered = result.OrderBy(a => a.MealName);
            var dto = _mapper.Map<List<MealDTO>>(ordered);
            foreach (var meal in dto)
            {
                meal.Kcal = Math.Round(meal.MealProducts.Sum(a=> (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity),2);
                meal.Protein = Math.Round(meal.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity),2);
                meal.Carbohydrates = Math.Round(meal.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity),2);
                meal.Fats = Math.Round(meal.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity),2);
            }
            return dto;
        }
    }
}
