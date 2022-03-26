using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Functions.Day.Command.DeleteDay;
using DietMealApp.Application.Functions.Day.Command.InsertDay;
using DietMealApp.Application.Functions.Day.Command.UpdateDay;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
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
            IMediator mediator
            ) : base(mediator)
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
                await _mediator.Send(new InsertDayCommand() { DayForm = model });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetDayByIdQuery() { Id = id, UserId = _senderId });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DayFormDTO model)
        {
            InitId();
            try
            {
                await _mediator.Send(new UpdateDayCommand() { DayForm = model });
                return RedirectToAction("Index", "Day");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReleoadMenu(int mealCount, Guid dayId = new Guid())
        {
            InitId();
            try
            {
                var day = await _mediator.Send(new GetDayByIdQuery() { Id= dayId });
                var meals = await _mediator.Send(new GetMealsByUserQuery() { UserId = _senderId });
                if (day != null)
                {
                    return PartialView("_MealMenu", model: new MealMenu { MealsCount = mealCount, Meals = meals, MealItems = day.MealItems });
                }
                return PartialView("_MealMenu", model: new MealMenu { MealsCount = mealCount, Meals = meals, MealItems = new List<MealMenuItemDTO>() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetDayByIdQuery() { Id = id });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DayFormDTO model)
        {
            InitId();
            try
            {
                await _mediator.Send(new DeleteDayCommand() { DayId = model.Id });
                return RedirectToAction("Index", "Day");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
