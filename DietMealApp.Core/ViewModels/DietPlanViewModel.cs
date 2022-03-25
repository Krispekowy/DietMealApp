using DietMealApp.Core.DTO.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public class DietPlanViewModel
    {
        public DayDTO Day { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
