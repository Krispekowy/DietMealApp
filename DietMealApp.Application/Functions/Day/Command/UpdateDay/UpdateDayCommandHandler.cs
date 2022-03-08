using AutoMapper;
using DietMealApp.Application.Factories.EntityFactories;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Core.Interfaces;
using DietMealApp.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var entity = DayFactory.CreateDayFromFormDto(request.DayForm);
            _dayRepository.Update(entity);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
