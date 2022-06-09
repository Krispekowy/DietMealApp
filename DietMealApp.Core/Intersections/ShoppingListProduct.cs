using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Intersections
{
    public class ShoppingListProduct
    {
        public Guid Id { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
