using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query.GetShoppingListBySearch
{
    public sealed class GetShoppingListBySearchQuery : IRequest<List<ShoppingListDTO>>
    {
        public string Query { get; set; }
    }
}
