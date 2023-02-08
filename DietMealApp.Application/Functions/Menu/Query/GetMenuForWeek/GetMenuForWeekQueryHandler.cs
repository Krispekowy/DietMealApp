using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Menu.Query.GetMenuForWeek
{
    public class GetMenuForWeekQueryHandler : BaseRequestHandler<GetMenuForWeekQuery, List<MenuDay>>
    {
        private readonly IPdfGenerator _pdfGenerator;

        public GetMenuForWeekQueryHandler(
            IMediator mediator,
            IFileManager fileManager,
            IPdfGenerator pdfGenerator) : base(mediator, fileManager)
        {
            _pdfGenerator = pdfGenerator;
        }
        public override async Task<List<MenuDay>> Handle(GetMenuForWeekQuery request, CancellationToken cancellationToken)
        {
            var result = new List<MenuDay>();
            foreach (var dayMenu in request.MenuDto)
            {
                var day = await _mediator.Send(new GetDayFormDTOByIdQuery() { Id = dayMenu.DayId, UserId = request.userId });
                if (day != null)
                {
                    result.Add(new MenuDay() { Day = DayDTO.CreateFromOtherDto(day), DayOfWeek = dayMenu.DayOfWeek });
                }
            }
            return result;
        }
    }
}
