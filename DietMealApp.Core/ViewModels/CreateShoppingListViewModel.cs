using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public class CreateShoppingListViewModel
    {
        public string UserId { get; set; }
        public List<ShoppingDaysDTO> Days { get; set; }
        public List<ShoppingMealsDTO> Meals { get; set; }
        public List<ShoppingListProductsDTO> Products { get; set; }
    }
}
