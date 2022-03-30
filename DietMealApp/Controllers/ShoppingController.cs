using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Application.Functions.Shopping.Query;
using DietMealApp.Core.DTO;
using DietMealApp.Core.ViewModels;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class ShoppingController : _ParentController
    {
        public ShoppingController(
            IMediator mediator
            ) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            InitId();
            try
            {
                var days = await _mediator.Send(new GetDaysByUserQuery() { UserId = _senderId });
                var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId= _senderId });
                GenerateShoppingListViewModel model = new GenerateShoppingListViewModel() { ListByDay = new List<ShoppingDaysDTO>(), ListByMeal = new List<ShoppingMealsDTO>()};
                foreach (var day in days)
                {
                    model.ListByDay.Add(new ShoppingDaysDTO() { Day = day, Quantity = 0 });
                }
                foreach (var meal in meals)
                {
                    model.ListByMeal.Add(new ShoppingMealsDTO() { Meal = meal, Quantity = 0 });
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Generate(GenerateShoppingListViewModel model)
        {
            InitId();
            try
            {
                var shoppingList = await _mediator.Send(new GetShoppingListQuery() {ShoppingListModel = model, UserId = _senderId });
                return PartialView("_ShoppingList", shoppingList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
