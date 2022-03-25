using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Days
{
    public class DayPlanDTO
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Guid DayId { get; set; }
        public List<DayDTO> Days { get; set; }
    }
}
