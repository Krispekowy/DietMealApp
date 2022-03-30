using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Core.DTO.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Menu.Query.GetMenuForm
{
    public class GetMenuFormQueryHandler : BaseRequestHandler<GetMenuFormQuery, List<MenuDTO>>
    {
        public GetMenuFormQueryHandler(IMediator mediator, IFileManager fileManager) : base (mediator, fileManager)
        {
        }

        public override async Task<List<MenuDTO>> Handle(GetMenuFormQuery request, CancellationToken cancellationToken)
        {
            var dto = new List<MenuDTO>();
            var days = await _mediator.Send(new GetDaysByUserQuery() { UserId = request.UserId});

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                dto.Add(new MenuDTO() { DayOfWeek = day, Days = days });
            }
            dto = dto.OrderBy(a => ((int)a.DayOfWeek + 6) % 7).ToList();
            return dto;
        }
    }
}
