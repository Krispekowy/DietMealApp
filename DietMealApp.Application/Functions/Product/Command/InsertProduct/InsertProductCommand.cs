using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Command
{
    public class InsertProductCommand : IRequest<Unit>
    {
        public ProductDTO Product { get; set; }
    }
}
