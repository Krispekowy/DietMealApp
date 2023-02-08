using DietMealApp.Core.DTO.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO
{
    public class ShoppingMealsDTO
    {
        public Guid MealId { get; set; }
        public int Quantity { get; set; }
    }
}
