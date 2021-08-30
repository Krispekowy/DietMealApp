using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser
{
    public class GetDaysByUserQueryHandler : IRequestHandler<GetDaysByUserQuery, List<DayDTO>>
    {
        private readonly IDayRepository _dietDayRepository;
        private readonly IMapper _mapper;

        public GetDaysByUserQueryHandler(
            IDayRepository dietDayRepository,
            IMapper mapper)
        {
            _dietDayRepository = dietDayRepository;
            _mapper = mapper;
        }

        public async Task<List<DayDTO>> Handle(GetDaysByUserQuery request, CancellationToken cancellationToken)
        {
            var days = await _dietDayRepository.GetDaysByUser(request.UserId);
            var dto = _mapper.Map<List<DayDTO>>(days);
            return dto;
        }
    }
}
