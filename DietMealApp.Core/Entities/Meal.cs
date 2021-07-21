using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietMealApp.Core.Entities
{
    public class Meal : _BaseEntity
    {
        public TypesOfMeal TypeOfMeal { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public int Kcal { get; set; }
        [ForeignKey("MealId")]
        public virtual List<MealProduct> MealProducts { get; set; } = new List<MealProduct>();
        public virtual List<DietDayMeals> DayDietMeals { get; set; }
    }
}
