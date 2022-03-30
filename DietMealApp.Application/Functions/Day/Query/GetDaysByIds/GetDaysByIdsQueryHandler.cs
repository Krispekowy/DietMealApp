using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
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
    public class GetDaysByIdsQueryHandler : BaseRequestHandler<GetDaysByIdsQuery, List<DayDTO>>
    {
        private readonly IDayRepository _dayRepository;

        public GetDaysByIdsQueryHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }
        public override async Task<List<DayDTO>> Handle(GetDaysByIdsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dayRepository.Get(a => request.Ids.Contains(a.Id)).ToListAsync();
            if (entities == null)
            {
                throw new NullReferenceException($"Days with Ids: { request.Ids} don't exist");
            }
            var dto = entities.Select(a=> DayDTO.CreateFromEntity(a)).ToList();
            return dto;
        }
    }
}
