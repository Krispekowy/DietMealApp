using DietMealApp.Core.DTO.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.ShoppingList
{
    public class ShoppingListMealsDTO
    {
        public int Quantity { get; set; }
        public Guid MealId { get; set; }
        public MealDTO Meal { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingListDTO ShoppingList { get; set; }
    }
}
