using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class DietDayController : _ParentController
    {
        private IMediator _mediator;

        public DietDayController(
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
                var model = await _mediator.Send(new GetDaysByUserQuery() { UserId = _senderId });
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
