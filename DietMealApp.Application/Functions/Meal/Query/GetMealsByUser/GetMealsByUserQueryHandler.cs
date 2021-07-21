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
            var ordered = result.OrderBy(a => a.MealName);
            return _mapper.Map<List<MealDTO>>(ordered);
        }
    }
}
