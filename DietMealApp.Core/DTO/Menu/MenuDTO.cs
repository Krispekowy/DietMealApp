using DietMealApp.Core.DTO.Days;
using System;
using System.Collections.Generic;

namespace DietMealApp.Core.DTO.Menu
{
    public class MenuDTO
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Guid DayId { get; set; }
        public List<DayDTO> Days { get; set; }
    }
}
