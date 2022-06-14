using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query.GetAllShoppingLists
{
    public class GetShoppingListsQuery : IRequest<List<ShoppingListDTO>>
    {
        public string UserId { get; set; }
    }
}
