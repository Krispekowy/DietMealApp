using DietMealApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public class GenerateShoppingListViewModel
    {
        public List<ShoppingDaysDTO> ListByDay { get; set; }
        public List<ShoppingMealsDTO> ListByMeal { get; set; }
        public string ListType { get; set; }
    }
}
