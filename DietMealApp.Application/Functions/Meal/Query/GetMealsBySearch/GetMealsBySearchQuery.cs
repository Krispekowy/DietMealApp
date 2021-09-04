using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Query.GetMealsBySearch
{
    public sealed class GetMealsBySearchQuery:IRequest<SelectList>
    {
        public string UserId { get; set; }
        public string Query { get; set; }
    }
}
