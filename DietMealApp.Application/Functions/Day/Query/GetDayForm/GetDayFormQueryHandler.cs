using AutoMapper;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDayForm
{
    public class GetDayFormQueryHandler : IRequestHandler<GetDayFormQuery, DayFormDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetDayFormQueryHandler(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<DayFormDTO> Handle(GetDayFormQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = request.UserId });
            var response = new DayFormDTO()
            {
                UserId = request.UserId,
                Kcal = 0,
                Name = "",
                MealMenu = new List<MealMenuItemDTO>() { new MealMenuItemDTO() },
                Meals = new SelectList(meals, "Id", "MealName")
            };
            return response;
        }


    }
}
