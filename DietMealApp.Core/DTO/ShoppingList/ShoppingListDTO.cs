using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public sealed class ShoppingListDTO : _BaseDTO
    {
        public static ShoppingListDTO CreateFromEntity(ShoppingList entity)
        {
            return new ShoppingListDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = entity.ShoppingListProducts.Select(a => new ProductsToBuyDTO()
                {
                    ProductId = a.ProductId,
                    Category = a.Product.Category,
                    Product = a.Product.ProductName,
                    Quantity = a.Quantity,
                    ShoppingListId = a.Id,
                }).ToList()
            };
        }
        public string Name { get; set; }
        public List<ProductsToBuyDTO> Products { get; set; }
    }
}
