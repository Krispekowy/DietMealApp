using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Intersections
{
    public class ShoppingListDays
    {
        public static ShoppingListDays CreateFromDTO(ShoppingDaysDTO shoppingDaysDTO)
        {
            return new ShoppingListDays()
            {
                Quantity = shoppingDaysDTO.Quantity,
                DayId = shoppingDaysDTO.DayId
            };
        }
        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public Guid DayId { get; set; }
        public Day Day { get; set; }
        public int Quantity { get; set; }
    }
}
