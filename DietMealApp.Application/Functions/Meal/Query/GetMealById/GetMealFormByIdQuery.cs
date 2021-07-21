using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Meals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Query.GetMealById
{
    public class GetMealFormByIdQuery : IRequest<MealFormDTO>
    {
        public Guid Id { get; set; }
    }
}
