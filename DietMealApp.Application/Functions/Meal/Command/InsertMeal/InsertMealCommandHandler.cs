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
using DietMealApp.Service.Functions.Query;

namespace DietMealApp.Application.Functions.Meal.Command.InsertMeal
{
    public class InsertMealCommandHandler : IRequestHandler<InsertMealCommand, Unit>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertMealCommandHandler(
            IMealRepository mealRepository,
            IMapper mapper,
            IMediator mediator
            )
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(InsertMealCommand request, CancellationToken cancellationToken)
        {
            await CalculateNutritionalValues(request);
            request.MealForm.MealProducts.RemoveAll(item => item.ProductId == Guid.Empty);
            var meal = _mapper.Map<DietMealApp.Core.Entities.Meal>(request.MealForm);
            _mealRepository.Insert(meal);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }

        private async Task CalculateNutritionalValues(InsertMealCommand request)
        {
            foreach (var product in request.MealForm.MealProducts)
            {
                var p = await _mediator.Send(new GetProductByIdQuery() { Id = product.ProductId });
                request.MealForm.Kcal = p.Kcal * (Decimal.Divide(product.Quantity.GetValueOrDefault(0), 100)) + request.MealForm.Kcal;
                request.MealForm.Protein = p.Protein * (Decimal.Divide(product.Quantity.GetValueOrDefault(0), 100)) + request.MealForm.Protein;
                request.MealForm.Fats = p.Fats * (Decimal.Divide(product.Quantity.GetValueOrDefault(0), 100)) + request.MealForm.Fats;
                request.MealForm.Carbohydrates = p.Carbohydrates * (Decimal.Divide(product.Quantity.GetValueOrDefault(0), 100)) + request.MealForm.Carbohydrates;
            }
        }
    }
}
