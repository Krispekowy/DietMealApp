using DietMealApp.Core.DTO.Products;
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
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }
    }
}
