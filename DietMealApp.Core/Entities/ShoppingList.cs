using DietMealApp.Core.DTO;
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
                ShoppingListProducts = dto.Products.Select(a => new ShoppingListProduct()
                {
                    ProductId = a.ProductId,
                    Quantity = a.Quantity,
                    ShoppingListId = a.ShoppingListId
                })
                .ToList()
            };
        }
        public string Name { get; set; }
        public virtual List<ShoppingListProduct> ShoppingListProducts { get; set; }

    }
}
