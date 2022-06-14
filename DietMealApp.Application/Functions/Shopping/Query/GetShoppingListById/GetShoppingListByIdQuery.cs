using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query.GetShoppingListById
{
    public class GetShoppingListByIdQuery : IRequest<ShoppingListDTO>
    {
        public Guid Id { get; set; }
    }
}
