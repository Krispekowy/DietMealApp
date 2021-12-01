using AutoMapper;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.UpdateDay
{
    public class UpdateDayCommandHandler : IRequestHandler<UpdateDayCommand, Unit>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateDayCommandHandler(
            IDayRepository dayRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateDayCommand request, CancellationToken cancellationToken)
        {
            await CalculateNutritionalValues(request);
            var entity = _mapper.Map<Core.Entities.Day>(request.DayForm);
            _dayRepository.Update(entity);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }

        private async Task CalculateNutritionalValues(UpdateDayCommand request)
        {
            foreach (var meal in request.DayForm.MealItems)
            {
                var m = await _mediator.Send(new GetMealFormByIdQuery() { Id = meal.SelectedMeal });
                request.DayForm.Kcal = m.Kcal + request.DayForm.Kcal;
                request.DayForm.Protein = m.Protein + request.DayForm.Protein;
                request.DayForm.Fats = m.Fats + request.DayForm.Fats;
                request.DayForm.Carbohydrates = m.Carbohydrates + request.DayForm.Carbohydrates;
            }
        }
    }
}
