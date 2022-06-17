using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.DTO.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public class EditShoppingListViewModel
    {
        public static EditShoppingListViewModel CreateFromDTO(ShoppingListDTO dto)
        {
            return new EditShoppingListViewModel()
            {
                Days = dto.Days,
                Meals = dto.Meals,
                Products = dto.Products,
                UserId = dto.UserId
            };
        }
        public string UserId { get; set; }
        public List<ShoppingListDaysDTO> Days { get; set; }
        public List<DayDTO> DaysToChoice { get; set; }
        public List<ShoppingListMealsDTO> Meals { get; set; }
        public List<MealDTO> MealsToChoice { get; set; }
        public List<ShoppingListProductsDTO> Products { get; set; }
    }
}
