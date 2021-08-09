using DietMealApp.Core.DTO;
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
