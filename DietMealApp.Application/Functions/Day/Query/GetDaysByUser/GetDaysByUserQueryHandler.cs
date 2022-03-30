using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
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
    public class GetDaysByUserQueryHandler : BaseRequestHandler<GetDaysByUserQuery, List<DayDTO>>
    {
        private readonly IDayRepository _dayRepository;

        public GetDaysByUserQueryHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }

        public override async Task<List<DayDTO>> Handle(GetDaysByUserQuery request, CancellationToken cancellationToken)
        {
            var days = await _dayRepository.GetDaysByUser(request.UserId);
            var dto = days.Select(a=> DayDTO.CreateFromEntity(a)).ToList();
            dto.Select(a=>a.DayMeals.OrderBy(a=>a.Type)).ToList();
            return dto;
        }
    }
}
