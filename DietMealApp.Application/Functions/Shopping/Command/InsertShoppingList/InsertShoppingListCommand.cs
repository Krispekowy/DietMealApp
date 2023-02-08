using DietMealApp.Core.DTO;
using DietMealApp.Core.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList
{
    public class InsertShoppingListCommand : IRequest<Guid>
    {
        public string UserId { get; set; }
        public List<ShoppingDaysDTO> Days { get; set; }
        public List<ShoppingMealsDTO> Meals { get; set; }
    }
}
