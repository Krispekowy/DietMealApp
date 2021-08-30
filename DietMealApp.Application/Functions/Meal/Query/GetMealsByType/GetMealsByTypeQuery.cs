using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Query.GetMealsByType
{
    public sealed class GetMealsByTypeQuery : IRequest<SelectList>
    {
        public string UserId { get; set; }
        public MealTimeType Type { get; set; }
    }
}
