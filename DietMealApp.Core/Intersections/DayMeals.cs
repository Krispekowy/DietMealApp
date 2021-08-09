using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Intersections
{
    public class DayMeals
    {
        public Guid DayId { get; set; }
        public Day Day { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
