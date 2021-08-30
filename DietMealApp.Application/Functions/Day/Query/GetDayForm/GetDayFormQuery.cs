using DietMealApp.Core.DTO.Days;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDayForm
{
    public class GetDayFormQuery : IRequest<DayFormDTO>
    {
        public string UserId { get; set; }
    }
}
