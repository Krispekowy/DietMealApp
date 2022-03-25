using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDaysByIds
{
    public class GetDaysByIdsQueryHandler : IRequestHandler<GetDaysByIdsQuery, List<DayDTO>>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;

        public GetDaysByIdsQueryHandler(
            IDayRepository dayRepository,
            IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }
        public async Task<List<DayDTO>> Handle(GetDaysByIdsQuery request, CancellationToken cancellationToken)
        {
            var entity = _dayRepository.Get(a => request.Ids.Contains(a.Id)).ToList();
            if (entity == null)
            {
                var empty = _mapper.Map<List<DayDTO>>(entity);
                return empty;
            }
            var dto = _mapper.Map<List<DayDTO>>(entity);
            return dto;
        }
    }
}
