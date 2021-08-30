using DietMealApp.Application.Functions.Day.Query.GetDayForm;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Core.DTO.Days;
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
    }
}
