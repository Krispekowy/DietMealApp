using DietMealApp.Application.Functions.Menu.Query.GetMenuForm;
using DietMealApp.Application.Functions.Menu.Query.GetMenuForWeek;
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
        public async Task<IActionResult> Generate(List<MenuDTO> model)
        {
            InitId();
            try
            {
                return PartialView("_Menu", await _mediator.Send(new GetMenuForWeekQuery() { MenuDto = model, userId = _senderId}));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
