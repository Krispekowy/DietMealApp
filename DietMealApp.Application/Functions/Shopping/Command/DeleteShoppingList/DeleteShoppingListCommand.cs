using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.DeleteShoppingList
{
    public class DeleteShoppingListCommand : IRequest<Unit>
    {
        public Guid ShoppingListId { get; set; }
    }
}
