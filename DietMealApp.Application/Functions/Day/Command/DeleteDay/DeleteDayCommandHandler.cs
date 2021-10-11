using AutoMapper;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.DeleteDay
{
    public class DeleteDayCommandHandler : IRequestHandler<DeleteDayCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDayRepository _dayRepository;

        public DeleteDayCommandHandler(IMapper mapper, IDayRepository dayRepository)
        {
            _mapper = mapper;
            _dayRepository = dayRepository;
        }

        public async Task<Unit> Handle(DeleteDayCommand request, CancellationToken cancellationToken)
        {
            await _dayRepository.Delete(request.DayId);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
