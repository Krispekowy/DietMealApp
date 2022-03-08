using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Day : _BaseEntity
    {
        public string Name { get; set; }
        public virtual List<DietDay> DietDays { get; set; }
        public virtual List<DayMeals> DayMeals { get; set; }
        public int NumberOfMeals { get; set; }
        public string UserId { get; set; }
    }
}
