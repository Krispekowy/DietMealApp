using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using DietMealApp.Service.Functions.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDayById
{
    public class GetDayFormDTOByIdQueryHandler : BaseRequestHandler<GetDayFormDTOByIdQuery, DayFormDTO>
    {
        private readonly IDayRepository _dayRepository;

        public GetDayFormDTOByIdQueryHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }
        public override async Task<DayFormDTO> Handle(GetDayFormDTOByIdQuery request, CancellationToken cancellationToken)
        {
            var day = await _dayRepository.GetByID(request.Id);
            if (day == null)
            {
                return null;
            }
            day.DayMeals = day.DayMeals.OrderBy(a => a.Type).ToList();
            var dto = DayFormDTO.CreateFromEntity(day);
            var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = request.UserId });
            dto.Meals = meals;
            return dto;
        }
    }
}
