using DietMealApp.Application.Functions.Day.Query.GetDayForm;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Core.DTO.Days;
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
    public class DayController : _ParentController
    {
        public DayController(
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
                var model = await _mediator.Send(new GetDaysByUserQuery() { UserId = _senderId });
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
                var model = await _mediator.Send(new GetDayFormQuery() { UserId = _senderId });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DayFormDTO model)
        {
            InitId();
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReleoadMenu(int mealCount)
        {
            InitId();
            try
            {
                var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = _senderId });
                return PartialView("_MenuMenu", model: new MealMenu { MealsCount = mealCount, Meals = meals, MealItems = new List<MealMenuItemDTO>( new MealMenuItemDTO[mealCount]) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
