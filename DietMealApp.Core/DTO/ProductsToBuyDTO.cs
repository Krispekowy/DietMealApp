using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public class ProductsToBuyDTO
    {
        public Guid ProductId { get; set; }
        public string Product { get; set; }
        public Guid ShoppingListId { get; set; }
        public ProductCategories Category { get; set; }
        public decimal Quantity { get; set; }
    }
}
