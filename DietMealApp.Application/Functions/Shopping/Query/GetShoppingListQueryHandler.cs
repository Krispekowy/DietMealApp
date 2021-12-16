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
        private readonly IMealRepository _mealRepository;

        public GetShoppingListQueryHandler(IMediator mediator, IDayRepository dayRepository, IMealRepository mealRepository)
        {
            _mediator = mediator;
            _dayRepository = dayRepository;
            _mealRepository = mealRepository;
        }

        public async Task<List<ProductsToBuyDTO>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            List<ProductsToBuyDTO> products = new List<ProductsToBuyDTO>();
            if(request.ShoppingListModel.ListType == "day")
            {
                foreach (var day in request.ShoppingListModel.ListByDay)
                {
                    if (day.Quantity > 0)
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
            }
            else
            {
                foreach (var meal in request.ShoppingListModel.ListByMeal)
                {
                    if (meal.Quantity > 0)
                    {
                        var mealDetails = await _mealRepository.GetByID(meal.Meal.Id);
                        if (mealDetails != null)
                        {
                                for (int i = 0; i < meal.Quantity; i++)
                                {
                                    products.AddRange(mealDetails.MealProducts.Select(a => new ProductsToBuyDTO() { Category = a.Product.Category, Product = a.Product.ProductName, Quantity = a.Quantity }).ToList());
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
