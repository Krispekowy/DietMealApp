using DietMealApp.Application.Functions.Meal.Command.DeleteMeal;
using DietMealApp.Application.Functions.Meal.Command.InsertMeal;
using DietMealApp.Application.Functions.Meal.Command.UpdateMeal;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Application.Functions.Meal.Query.GetMealsBySearch;
using DietMealApp.Application.Functions.Meal.Query.GetMealsByType;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Enums;
using DietMealApp.Core.ViewModels;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class MealController : _ParentController
    {
        public MealController(
            IConfiguration configuration,
            IMediator mediator
            ) : base(configuration, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetMealsByUserQuery() { UserId = _senderId });
                return View(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            InitId();
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery() { OrderBy = OrderByProductOptions.ByName});
                var model = new MealFormDTO()
                {
                    Products = products,
                    UserId = _senderId
                };
                return View(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MealFormDTO model)
        {
            InitId();
            try
            {
                await _mediator.Send(new InsertMealCommand() { MealForm = model });
                return RedirectToAction("Index","Meal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetMealFormByIdQuery() { Id = id });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Copy(Guid id)
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetMealFormByIdQuery() { Id = id });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Copy(MealFormDTO model)
        {
            InitId();
            try
            {
                model.Id = Guid.Empty;
                await _mediator.Send(new InsertMealCommand() { MealForm = model });
                return RedirectToAction("Index", "Meal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MealFormDTO model)
        {
            InitId();
            try
            {
                await _mediator.Send(new UpdateMealCommand() { MealForm = model });
                return RedirectToAction("Index", "Meal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetMealFormByIdQuery() { Id = id });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MealFormDTO model)
        {
            InitId();
            try
            {
                await _mediator.Send(new DeleteMealCommand() { Id = model.Id });
                return RedirectToAction("Index", "Meal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMealsByType([FromQuery] MealTimeType type)
        {
            InitId();
            try
            {
                var meals = await _mediator.Send(new GetMealsByTypeQuery() { Type = type, UserId = _senderId });
                return Json(meals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMealsBySearchQuery([FromQuery] string query = "")
        {
            InitId();
            try
            {
                var meals = await _mediator.Send(new GetMealsBySearchQuery() { UserId = _senderId, Query = query });
                return Json(meals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddProductRow(int index)
        {
            InitId();
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery() { OrderBy = OrderByProductOptions.ByName});
                return PartialView("_ProductRow", model: new ProductRow { Index = index, Products = products });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
