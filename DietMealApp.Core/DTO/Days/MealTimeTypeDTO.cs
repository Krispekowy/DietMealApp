using DietMealApp.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Days
{
    public sealed class MealTimeTypeDTO
    {
        public SelectListItem MealName { get; set; }
        public MealTimeType DefaultMealTimeType { get; set; }
    }
}
