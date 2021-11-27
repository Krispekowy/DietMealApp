using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Diet.Query.GetDietsByUser
{
    public class GetDietsByUserQuery : IRequest<List<DietDTO>>
    {
        public string UserId { get; set; }
    }
}
