using AutoMapper;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Command.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;

        public UpdateMealCommandHandler(
            IMapper mapper,
            IMealRepository mealRepository)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
        }

        public async Task<Unit> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = _mapper.Map<DietMealApp.Core.Entities.Meal>(request.MealForm);
            _mealRepository.Update(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
