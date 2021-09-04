using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Product.Query.GetProductsBySearch
{
    public sealed class GetProductsBySearchQuery : IRequest<SelectList>
    {
        public string Query { get; set; }
    }
}
