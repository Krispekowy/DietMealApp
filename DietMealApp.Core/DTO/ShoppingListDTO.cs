﻿using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public sealed class ShoppingListDTO
    {
        public ProductCategories Category { get; set; }
        public List<ProductsToBuyDTO> Products { get; set; }
    }
}
