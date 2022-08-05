using DietMealApp.Core.DTO.Days;
using System;
using System.Collections.Generic;

namespace DietMealApp.Core.ViewModels
{
    public class MenuDay
    {
        public DayDTO Day { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string DayOfWeekString { get; set; }
        public string DayDescription { get; set; }
        public List<MealPdfViewModel> Meals { get; set; }
    }
}