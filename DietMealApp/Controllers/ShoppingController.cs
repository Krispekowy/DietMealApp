using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Application.Functions.PDFGenerator.Query.GetShoppingList;
using DietMealApp.Application.Functions.Shopping.Command.DeleteShoppingList;
using DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList;
using DietMealApp.Application.Functions.Shopping.Query;
using DietMealApp.Application.Functions.Shopping.Query.GetAllShoppingLists;
using DietMealApp.Application.Functions.Shopping.Query.GetShoppingListById;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.ShoppingList;
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
            IMediator mediator,
            IDeviceDetector deviceDetector
            ) : base(mediator, deviceDetector)
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
        public async Task<IActionResult> Create(CreateShoppingListViewModel model)
        {
            InitId();
            try
            {
                Guid id = await _mediator.Send(new InsertShoppingListCommand() { Days = model.Days, Meals = model.Meals, UserId = _senderId });
                return RedirectToAction("Edit", new { id = id });
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

        [HttpPost]
        public async Task<IActionResult> Save(EditShoppingListViewModel model)
        {
            InitId();
            try
            {
                var file = await _mediator.Send(new GetShoppingListPDFQuery() { ListOfProducts = model.ShoppingListPdf });
                return File(file.Item1, "application/pdf", file.Item2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
                throw;
            }
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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new GetShoppingListByIdQuery() { Id = id });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ShoppingListDTO dto)
        {
            await _mediator.Send(new DeleteShoppingListCommand() { ShoppingListId = dto.Id });
            return RedirectToAction("Index");
        }
    }
}
