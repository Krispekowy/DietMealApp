using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Intersections
{
    public class DietDay
    {
        public Guid DayId { get; set; }
        public Day Day { get; set; }
        public Guid DietId { get; set; }
        public Diet Diet { get; set; }
    }
}
