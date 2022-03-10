﻿using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietMealApp.Core.Entities
{
    public class Meal : _BaseEntity
    {
        public MealTimeType TypeOfMeal { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int NumberOfServings { get; set; }
        public string Photo150x150Path { get; set; }
        public string PhotoFullPath { get; set; }
        [ForeignKey("MealId")]
        public virtual List<MealProduct> MealProducts { get; set; } = new List<MealProduct>();
        public virtual List<DayMeals> DayMeals { get; set; }
    }
}
