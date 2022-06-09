﻿using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Entities
{
    public class ShoppingList : _BaseEntity
    {
        public string Name { get; set; }
        public virtual List<ShoppingListProduct> ShoppingListProducts { get; set; }
    }
}
