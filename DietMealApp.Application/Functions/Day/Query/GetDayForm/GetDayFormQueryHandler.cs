using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Interfaces;
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
    public class GetDayFormQueryHandler : BaseRequestHandler<GetDayFormQuery, DayFormDTO>
    {
        private readonly IDayRepository _dayRepository;

        public GetDayFormQueryHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }
        public override async Task<DayFormDTO> Handle(GetDayFormQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = request.UserId });
            var response = new DayFormDTO()
            {
                UserId = request.UserId,
                Name = ""
            };
            return response;
        }


    }
}
