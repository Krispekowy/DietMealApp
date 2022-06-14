using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList
{
    public class InsertShoppingListCommand : IRequest<Unit>
    {
        public ShoppingListDTO ShoppingList { get; set; }
    }
}
