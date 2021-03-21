using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class DietDayMeals : _BaseEntity
    {
        public int DietDayId { get; set; }
        public DietDay DayDiet { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int TypeOfMeal { get; set; }
    }
}
