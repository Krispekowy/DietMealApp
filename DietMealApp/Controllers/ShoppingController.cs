using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Application.Functions.Shopping.Query;
using DietMealApp.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class ShoppingController : _ParentController
    {
        public ShoppingController(
            IMediator mediator
            ) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            InitId();
            try
            {
                var days = await _mediator.Send(new GetDaysByUserQuery() { UserId = _senderId });
                List<ShoppingDaysDTO> model = new List<ShoppingDaysDTO>();
                foreach (var day in days)
                {
                    model.Add(new ShoppingDaysDTO() { Day = day, Quantity = 0 });
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Generate(List<ShoppingDaysDTO> model)
        {
            InitId();
            try
            {
                var shoppingList = await _mediator.Send(new GetShoppingListQuery() {Days = model });
                return PartialView("_ShoppingList", shoppingList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
