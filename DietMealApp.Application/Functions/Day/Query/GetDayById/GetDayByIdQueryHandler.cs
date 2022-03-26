using AutoMapper;
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
    public class GetDayByIdQueryHandler : IRequestHandler<GetDayByIdQuery, DayFormDTO>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMediator _mediator;

        public GetDayByIdQueryHandler(
            IDayRepository dayRepository,
            IMediator mediator)
        {
            _dayRepository = dayRepository;
            _mediator = mediator;
        }
        public async Task<DayFormDTO> Handle(GetDayByIdQuery request, CancellationToken cancellationToken)
        {
            var day = await _dayRepository.GetByID(request.Id);
            var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = request.UserId });
            if (day == null)
            {
                return null;
            }
            day.DayMeals = day.DayMeals.OrderBy(a => a.Type).ToList();
            var dto = DayFormDTO.CreateFromEntity(day);
            dto.Meals = meals;
            return dto;
        }
    }
}
