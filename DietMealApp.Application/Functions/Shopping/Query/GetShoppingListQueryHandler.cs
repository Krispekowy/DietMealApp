using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
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
    public class GetShoppingListQueryHandler : BaseRequestHandler<GetShoppingListQuery, List<ProductsToBuyDTO>>
    {
        public GetShoppingListQueryHandler(
            IMediator mediator, 
            IFileManager fileManager) : 
            base(mediator, fileManager)
        { }

        public override async Task<List<ProductsToBuyDTO>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            List<ProductsToBuyDTO> products = new List<ProductsToBuyDTO>();
            
            //    foreach (var day in request.ShoppingListModel.Days)
            //    {
            //        if (day.Quantity > 0)
            //        {
            //            var dayEntity = await _mediator.Send(new GetDayByIdQuery() { Id = day.DayId, UserId = request.UserId });
            //            if (dayEntity != null)
            //            {
            //                foreach (var product in dayEntity.DayMeals)
            //                {
            //                    for (int i = 0; i < day.Quantity; i++)
            //                    {
            //                        products.AddRange(product.Meal.MealProducts.Select(a => new ProductsToBuyDTO() { Category = a.Product.Category, Product = a.Product.ProductName, Quantity = a.Quantity }).ToList());
            //                    }
            //                }
            //            }
            //        }
            //    }
            
            //    foreach (var meal in request.ShoppingListModel.Meals)
            //    {
            //        if (meal.Quantity > 0)
            //        {
            //            var mealDetails = await _mediator.Send(new GetMealFormByIdQuery() { Id = meal.MealId});
            //            if (mealDetails != null)
            //            {
            //                    for (int i = 0; i < meal.Quantity; i++)
            //                    {
            //                        products.AddRange(mealDetails.MealProducts.Select(a => new ProductsToBuyDTO() { Category = a.Product.Category, Product = a.Product.ProductName, Quantity = a.Quantity }).ToList());
            //                    }
            //            }
            //        }
            //    }
            
            //var groupedProducts = products.GroupBy(a => a.Product).Select(b => new ProductsToBuyDTO() { Product = b.Key, Quantity = b.Sum(c => c.Quantity), Category = b.First().Category }).ToList();
            return products;
        }
    }
}
