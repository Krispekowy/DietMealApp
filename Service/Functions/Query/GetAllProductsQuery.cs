using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Query
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
        public OrderByProductOptions OrderBy { get; set; }
    }
}
