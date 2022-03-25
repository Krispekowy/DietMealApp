using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDaysByIds
{
    public class GetDaysByIdsQuery : IRequest<List<DayDTO>>
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}
