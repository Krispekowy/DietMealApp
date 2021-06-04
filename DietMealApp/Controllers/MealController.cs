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
    }
}
