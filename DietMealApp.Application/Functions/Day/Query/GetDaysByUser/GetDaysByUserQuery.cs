using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser
{
    public class GetDaysByUserQuery : IRequest<List<DayDTO>>
    {
        public string UserId { get; set; }
    }
}
