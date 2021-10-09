using AutoMapper;
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

        public InsertDayCommandHandler(IDayRepository dayRepository, IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
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
