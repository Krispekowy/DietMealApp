using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Meals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Command.InsertMeal
{
    public class InsertMealCommand : IRequest<Unit>
    {
        public MealFormDTO MealForm { get; set; }
    }
}
