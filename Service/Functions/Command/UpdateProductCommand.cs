using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Command
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductDTO Product { get; set; }
    }
}
