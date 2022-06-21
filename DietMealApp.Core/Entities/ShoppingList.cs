using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.ShoppingList;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Entities
{
    public class ShoppingList : _BaseEntity
    {
        public static ShoppingList CreateFromDto(ShoppingListDTO dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new ShoppingList()
            {
                Id = dto.Id,
                Name = dto.Name,
                UserId = dto.UserId,
                ShoppingListProducts = dto.Products.Select(a => new ShoppingListProduct()
                {
                    ProductId = a.ProductId,
                    Quantity = a.Quantity,
                    ShoppingListId = a.ShoppingListId
                })
                .ToList(),
                ShoppingListDays = dto.Days.Select(a => new ShoppingListDays()
                {
                    DayId = a.DayId,
                    Quantity = a.Quantity,
                    ShoppingListId = a.ShoppingListId
                }).ToList(),
                ShoppingListMeals = dto.Meals.Select(a=> new ShoppingListMeals()
                {
                    MealId = a.MealId,
                    Quantity= a.Quantity,
                    ShoppingListId= a.ShoppingListId
                }).ToList()
            };
        }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual List<ShoppingListMeals> ShoppingListMeals { get; set; }
        public virtual List<ShoppingListDays> ShoppingListDays { get; set; }
        public virtual List<ShoppingListProduct> ShoppingListProducts { get; set; }

    }
}
