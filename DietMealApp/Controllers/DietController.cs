using DietMealApp.Application.Functions.Diet.Query.GetDietsByUser;
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
    }
}
