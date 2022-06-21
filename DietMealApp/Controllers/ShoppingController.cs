using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList;
using DietMealApp.Application.Functions.Shopping.Query;
using DietMealApp.Application.Functions.Shopping.Query.GetAllShoppingLists;
using DietMealApp.Application.Functions.Shopping.Query.GetShoppingListById;
using DietMealApp.Core.DTO;
using DietMealApp.Core.ViewModels;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Index()
        {
            InitId();
            var model = await _mediator.Send(new GetShoppingListsQuery() { UserId = _senderId });
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            InitId();
            return View(model: new CreateShoppingListViewModel() { UserId = _senderId });
        }

        [HttpPost]
        public async Task<IActionResult> Generate(CreateShoppingListViewModel model)
        {
            InitId();
            try
            {
                var shoppingList = await _mediator.Send(new GetShoppingListQuery() { ShoppingListModel = model, UserId = _senderId });
                return PartialView("_ShoppingList", shoppingList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateShoppingListViewModel model)
        {
            InitId();
            try
            {
                await _mediator.Send(new InsertShoppingListCommand() { Days = model.Days, Meals = model.Meals, UserId = _senderId });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            InitId();
            var shoppingListDTO = await _mediator.Send(new GetShoppingListByIdQuery() { Id = id });
            var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = _senderId });
            var days = await _mediator.Send(new GetDaysByUserQuery() { UserId = _senderId });
            var model = new EditShoppingListViewModel()
            {
                Days = shoppingListDTO.Days,
                DaysToChoice = days,
                Meals = shoppingListDTO.Meals,
                MealsToChoice = meals,
                Products = shoppingListDTO.Products,
                UserId = _senderId
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddMealRow(int index)
        {
            InitId();
            var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = _senderId });
            var model = new MealRow() { Index = index, Meals = meals };
            return PartialView("_MealRow", model);
        }

        [HttpGet]
        public async Task<IActionResult> AddDayRow(int index)
        {
            InitId();
            var days = await _mediator.Send(new GetDaysByUserQuery() { UserId = _senderId });
            var model = new DayRow() { Index = index, Days = days };
            return PartialView("_DayRow", model);
        }
    }
}
