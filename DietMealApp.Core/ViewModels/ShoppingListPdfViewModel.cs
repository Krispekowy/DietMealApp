using DietMealApp.Core.Enums;
using System.Collections.Generic;

namespace DietMealApp.Core.ViewModels
{
    public class ShoppingListPdfViewModel
    {
        public ProductCategories Category { get; set; }
        public List<ProductWithQuantity> Products { get; set; }
    }
}