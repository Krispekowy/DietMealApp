using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.DeleteDay
{
    public class DeleteDayCommand : IRequest<Unit>
    {
        public Guid DayId { get; set; }
    }
}
