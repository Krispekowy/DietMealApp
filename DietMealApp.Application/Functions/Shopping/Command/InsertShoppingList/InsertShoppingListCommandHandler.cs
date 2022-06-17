using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.DTO.ShoppingList;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using DietMealApp.Core.Intersections;
using DietMealApp.Core.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList
{
    public class InsertShoppingListCommandHandler : BaseRequestHandler<InsertShoppingListCommand, Guid>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public InsertShoppingListCommandHandler(
            IShoppingListRepository shoppingListRepository,
            IMediator mediator,
            IFileManager fileManager
            ) : base(mediator, fileManager)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        public override async Task<Guid> Handle(InsertShoppingListCommand request, CancellationToken cancellationToken)
        {
            List<ShoppingListProductsDTO> products = new List<ShoppingListProductsDTO>();

            foreach (var day in request.Days)
            {
                if (day.Quantity > 0)
                {
                    var dayEntity = await _mediator.Send(new GetDayByIdQuery() { Id = day.DayId, UserId = request.UserId });
                    if (dayEntity != null)
                    {
                        foreach (var product in dayEntity.DayMeals)
                        {
                            for (int i = 0; i < day.Quantity; i++)
                            {
                                products.AddRange(product.Meal.MealProducts.Select(a => new ShoppingListProductsDTO() { ProductId = a.Product.Id, Quantity = a.Quantity }).ToList());
                            }
                        }
                    }
                }
            }

            foreach (var meal in request.Meals)
            {
                if (meal.Quantity > 0)
                {
                    var mealDetails = await _mediator.Send(new GetMealFormByIdQuery() { Id = meal.MealId });
                    if (mealDetails != null)
                    {
                        for (int i = 0; i < meal.Quantity; i++)
                        {
                            products.AddRange(mealDetails.MealProducts.Select(a => new ShoppingListProductsDTO() { ProductId = a.Product.Id, Quantity = a.Quantity }).ToList());
                        }
                    }
                }
            }

            var groupedProducts = products.GroupBy(a => a.ProductId).Select(a => new ShoppingListProductsDTO() { ProductId = a.Key, Quantity = a.Sum(c => c.Quantity)}).ToList();
            var model = new CreateShoppingListViewModel()
            {
                Meals = request.Meals,
                Days = request.Days,
                Products = groupedProducts
            };
            var dto = ShoppingListDTO.CreateFromViewModel(model);
            var entity = ShoppingList.CreateFromDto(dto);
            _shoppingListRepository.Insert(entity);
            await _shoppingListRepository.CommitAsync();
            return entity.Id;
        }
    }
}
