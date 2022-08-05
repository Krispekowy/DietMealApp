using DietMealApp.Application.Functions.Menu.Query.GetMenuForm;
using DietMealApp.Application.Functions.Menu.Query.GetMenuForWeek;
using DietMealApp.Application.Functions.PDFGenerator.Query.GetMenu;
using DietMealApp.Core.DTO.Menu;
using DietMealApp.Core.ViewModels;
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
                MenuWeeklyViewModel model = new MenuWeeklyViewModel();
                model.Days = await _mediator.Send(new GetMenuFormQuery() { UserId = _senderId });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Generate(MenuWeeklyViewModel model)
        {
            InitId();
            try
            {
                return PartialView("_Menu", await _mediator.Send(new GetMenuForWeekQuery() { MenuDto = model.Days, userId = _senderId}));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(MenuWeeklyViewModel model)
        {
            InitId();
            try
            {
                var file = await _mediator.Send(new GetMenuPDFQuery() { MenuDays = model.MenuDays });
                return File(file.Item1, "application/pdf", file.Item2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
