using AutoMapper;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DietMealApp.Core.Entities;

namespace DietMealApp.Application.Functions.Meal.Command.InsertMeal
{
    public class InsertMealCommandHandler : IRequestHandler<InsertMealCommand, Unit>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public InsertMealCommandHandler(
            IMealRepository mealRepository,
            IMapper mapper
            )
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertMealCommand request, CancellationToken cancellationToken)
        {
            request.MealForm.MealProducts.RemoveAll(item => item.ProductId == Guid.Empty);
            var meal = _mapper.Map<DietMealApp.Core.Entities.Meal>(request.MealForm);
            _mealRepository.Insert(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
