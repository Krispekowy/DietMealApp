using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class DietDayMeals
    {
        public Guid DietDayId { get; set; }
        public DietDay DayDiet { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
