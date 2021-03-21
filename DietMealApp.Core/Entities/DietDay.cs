using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class DietDay : _BaseEntity
    {
        public string DayName { get; set; }
        public int DietId { get; set; }
        public Diet Diet { get; set; }
        public virtual List<DietDayMeals> DayDietMeals { get; set; }
        
        public int Kcal { get; set; }
    }
}
