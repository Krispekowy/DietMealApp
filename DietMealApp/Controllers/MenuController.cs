using DietMealApp.Application.Functions.Menu.Query.GetMenuForm;
using DietMealApp.Core.DTO.Menu;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class MenuController : _ParentController
    {
        public MenuController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            InitId();
            try
            {
                var model = await _mediator.Send(new GetMenuFormQuery() { UserId = _senderId });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePlan(List<MenuDTO> model)
        {
            InitId();
            return null;
            //try
            //{
            //    var plan = new List<DietPlanViewModel>();
            //    foreach (var dayMenu in model)
            //    {
            //        var day = await _mediator.Send(new GetDayByIdQuery() { Id = dayMenu.DayId });
            //        //plan.Add(new DietPlanViewModel() { Day = day, DayOfWeek = dayMenu.DayOfWeek });
            //    }

            //    return PartialView("_Plan", plan);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //    throw;
            //}
        }
    }
}
