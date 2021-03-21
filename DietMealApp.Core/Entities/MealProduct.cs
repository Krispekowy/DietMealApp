using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class MealProduct : _BaseEntity
    {
        public int? Quantity { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
