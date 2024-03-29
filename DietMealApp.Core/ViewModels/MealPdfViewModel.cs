﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public class MealPdfViewModel
    {
        public string Type { get; set; }
        public string Nutrition { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Description { get; set; }
    }
}
