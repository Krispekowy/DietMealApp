using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Intersections
{
    public class ShoppingListMeals
    {
        public Guid Id { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public int Quantity { get; set; }
    }
}
