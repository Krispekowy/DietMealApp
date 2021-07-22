using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Command.DeleteMeal
{
    public class DeleteMealCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
