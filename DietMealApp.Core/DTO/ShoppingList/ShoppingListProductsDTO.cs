using DietMealApp.Core.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.ShoppingList
{
    public class ShoppingListProductsDTO
    {
        public Guid Id { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingListDTO ShoppingList { get; set; }
        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
