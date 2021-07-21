using DietMealApp.Core.DTO.Meals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Command.UpdateMeal
{
    public class UpdateMealCommand : IRequest<Unit>
    {
        public MealFormDTO MealForm { get; set; }
    }
}
