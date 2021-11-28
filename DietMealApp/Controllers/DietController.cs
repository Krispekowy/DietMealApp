using DietMealApp.Application.Functions.Diet.Command;
using DietMealApp.Application.Functions.Diet.Query.GetDietsByUser;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Core.DTO;
using DietMealApp.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class DietController : _ParentController
    {
        public DietController(
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
                var model = await _mediator.Send(new GetDietsByUserQuery() { UserId = _senderId });
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
                var model = new DietDTO() { UserId = Guid.Parse(_senderId) };
                return View(model);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(DietDTO model)
        {
            InitId();
            try
            {
                await _mediator.Send(new InsertDietCommand() { DietDTO = model });
                return RedirectToAction("Index", "Diet");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddDayRow(int index)
        {
            InitId();
            try
            {
                var days = await _mediator.Send(new GetDaysByUserQuery());
                return PartialView("_DayRow", model: new DayRow { Index = index, Days = days });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
