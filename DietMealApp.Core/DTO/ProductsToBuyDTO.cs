using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public class ProductsToBuyDTO
    {
        public string Product { get; set; }
        public ProductCategories Category { get; set; }
        public int Quantity { get; set; }
    }
}
