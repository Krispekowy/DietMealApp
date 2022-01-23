using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Intersections
{
    public class DayMeals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid DayId { get; set; }
        public Day Day { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public MealTimeType Type { get; set; }
    }
}
