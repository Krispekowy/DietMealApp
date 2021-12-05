using DietMealApp.Core.DTO;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query
{
    public class GetShoppingListQueryHandler : IRequestHandler<GetShoppingListQuery, List<ProductsToBuyDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IDayRepository _dayRepository;

        public GetShoppingListQueryHandler(IMediator mediator, IDayRepository dayRepository)
        {
            _mediator = mediator;
            _dayRepository = dayRepository;
        }

        public async Task<List<ProductsToBuyDTO>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            List<ProductsToBuyDTO> products = new List<ProductsToBuyDTO>();
            foreach (var day in request.Days)
            {
                if(day.Quantity > 0)
                {
                    var dayDetails = await _dayRepository.GetByID(day.Day.Id);
                    if (dayDetails != null)
                    {
                        foreach (var product in dayDetails.DayMeals)
                        {
                            for (int i = 0; i < day.Quantity; i++)
                            {
                                products.AddRange(product.Meal.MealProducts.Select(a => new ProductsToBuyDTO() { Category = a.Product.Category, Product = a.Product.ProductName, Quantity = a.Quantity }).ToList());
                            }
                        }
                    }
                }
            }
            var groupedProducts = products.GroupBy(a => a.Product).Select(b => new ProductsToBuyDTO() { Product = b.Key, Quantity = b.Sum(c => c.Quantity), Category = b.First().Category }).ToList();
            return groupedProducts;
        }
    }
}
