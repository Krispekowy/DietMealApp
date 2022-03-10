using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser
{
    public class GetDaysByUserQueryHandler : IRequestHandler<GetDaysByUserQuery, List<DayDTO>>
    {
        private readonly IDayRepository _dietDayRepository;
        private readonly IMapper _mapper;

        public GetDaysByUserQueryHandler(
            IDayRepository dietDayRepository,
            IMapper mapper)
        {
            _dietDayRepository = dietDayRepository;
            _mapper = mapper;
        }

        public async Task<List<DayDTO>> Handle(GetDaysByUserQuery request, CancellationToken cancellationToken)
        {
            var days = await _dietDayRepository.GetDaysByUser(request.UserId);
            var dto = _mapper.Map<List<DayDTO>>(days);
            foreach (var day in dto)
            {
                day.Kcal = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity), 2));
                day.Protein = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity), 2));
                day.Carbohydrates = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity), 2));
                day.Fats = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity), 2));
            }
            return dto;
        }
    }
}
