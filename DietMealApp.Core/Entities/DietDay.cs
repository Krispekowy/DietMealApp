using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class DietDay : _BaseEntity
    {
        public string Name { get; set; }
        public int DietId { get; set; }
        public int Breakfast { get; set; }
        public int Brunch { get; set; }
        public int Lunch { get; set; }
        public int Tea { get; set; }
        public int Dinner { get; set; }
        public Diet Diet { get; set; }
        public virtual List<DietDayMeals> DayDietMeals { get; set; }
        
        public int Kcal { get; set; }
    }
}
