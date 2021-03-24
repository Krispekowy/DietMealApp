using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Product : _BaseEntity
    {
        public string ProductName { get; set; }
        public int Kcal { get; set; }
        public int QuantityUnit { get; set; }
        public Unit Unit { get; set; }
        public ProductCategories Category { get; set; }
        public virtual List<MealProduct> MealProducts { get; set; }
        public string PhotoPath { get; set; }
    }
}
