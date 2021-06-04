using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Query
{
    public class GetMealsByUserQuery : IRequest<List<MealDTO>>
    {
        public string UserId { get; set; }
    }
}
