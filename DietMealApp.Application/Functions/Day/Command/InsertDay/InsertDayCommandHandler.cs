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

namespace DietMealApp.Application.Functions.Day.Command.InsertDay
{
    public class InsertDayCommandHandler : IRequestHandler<InsertDayCommand, Unit>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertDayCommandHandler(IDayRepository dayRepository, IMapper mapper, IMediator mediator)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(InsertDayCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DietMealApp.Core.Entities.Day>(request.DayForm);
            _dayRepository.Insert(entity);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
