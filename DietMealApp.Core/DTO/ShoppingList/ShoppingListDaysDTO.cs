using DietMealApp.Core.DTO.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.ShoppingList
{
    public class ShoppingListDaysDTO
    {
        public int Quantity { get; set; }
        public Guid DayId { get; set; }
        public DayDTO Day { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingListDTO ShoppingList { get; set; }
    }
}
