using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Days
{
    public sealed class MealMenuItemDTO
    {
        public List<SelectListItem> Meals { get; set; }
        public MealDTO SelectedMeal { get; set; }
        public MealTimeType AssignedMealTimeType { get; set; }
    }
}
