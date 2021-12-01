using DietMealApp.Core.DTO.Days;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.UpdateDay
{
    public class UpdateDayCommand : IRequest<Unit>
    {
        public DayFormDTO DayForm { get; set; }
    }
}
