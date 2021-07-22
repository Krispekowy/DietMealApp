using DietMealApp.Application.Functions.Meal.Command.DeleteMeal;
using DietMealApp.Application.Functions.Meal.Command.InsertMeal;
using DietMealApp.Application.Functions.Meal.Command.UpdateMeal;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Core.DTO.Meals;
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
        private readonly IMediator _mediator;

        public MealController(
            IConfiguration configuration,
            IMediator mediator
            ) : base(configuration)
        {
            _mediator = mediator;
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
                var products = await _mediator.Send(new GetAllProductsQuery());
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
    }
}
