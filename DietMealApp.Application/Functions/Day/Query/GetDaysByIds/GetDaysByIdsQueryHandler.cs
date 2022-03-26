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

        public GetDaysByIdsQueryHandler(
            IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }
        public async Task<List<DayDTO>> Handle(GetDaysByIdsQuery request, CancellationToken cancellationToken)
        {
            var entities = _dayRepository.Get(a => request.Ids.Contains(a.Id)).ToList();
            if (entities == null)
            {
                throw new NullReferenceException($"Days with Ids: { request.Ids} don't exist");
            }
            var dto = entities.Select(a=> DayDTO.CreateFromEntity(a)).ToList();
            return dto;
        }
    }
}
