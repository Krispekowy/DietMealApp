using DietMealApp.Core.DTO.Days;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public class ShoppingDaysDTO
    {
        public Guid DayId { get; set; }
        public int Quantity { get; set; }
    }
}
