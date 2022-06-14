using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.UpdateShoppingList
{
    public class UpdateShoppingListCommand : IRequest<Unit>
    {
        public ShoppingListDTO ShoppingList { get; set; }
    }
}
