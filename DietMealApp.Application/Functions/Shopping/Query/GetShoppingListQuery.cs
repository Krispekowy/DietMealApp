using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query
{
    public class GetShoppingListQuery : IRequest<List<ProductsToBuyDTO>>
    {
        public List<ShoppingDaysDTO> Days { get; set; }
    }
}
