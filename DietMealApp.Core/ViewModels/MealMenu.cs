using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public sealed class MealMenu
    {
        public int MealsCount { get; set; }
        public List<MealMenuItemDTO> MealItems { get; set; }
        public List<MealDTO> Meals { get; set; }
    }
}
