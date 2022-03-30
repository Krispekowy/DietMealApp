using DietMealApp.Application.Commons.Abstract;
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
    public class GetMenuForWeekQueryHandler : BaseRequestHandler<GetMenuForWeekQuery, List<MenuWeeklyViewModel>>
    {
        public GetMenuForWeekQueryHandler(
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
        }
        public override async Task<List<MenuWeeklyViewModel>> Handle(GetMenuForWeekQuery request, CancellationToken cancellationToken)
        {
            var result = new List<MenuWeeklyViewModel>();
            foreach (var dayMenu in request.MenuDto)
            {
                var day = await _mediator.Send(new GetDayByIdQuery() { Id = dayMenu.DayId, UserId = request.userId });
                if (day != null)
                {
                    result.Add(new MenuWeeklyViewModel() { Day = DayDTO.CreateFromOtherDto(day), DayOfWeek = dayMenu.DayOfWeek });
                }
            }
            return result;
        }
    }
}
