using AutoMapper;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDayById
{
    public class GetDayByIdQueryHandler : IRequestHandler<GetDayByIdQuery, DayFormDTO>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;

        public GetDayByIdQueryHandler(
            IDayRepository dayRepository,
            IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }
        public Task<DayFormDTO> Handle(GetDayByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
