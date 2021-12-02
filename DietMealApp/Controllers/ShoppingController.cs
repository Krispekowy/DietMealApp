using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
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
            IConfiguration configuration,
            IMediator mediator
            ) : base(configuration, mediator)
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
                var products = new List<ProductsToBuyDTO>();
                products.Add(new ProductsToBuyDTO() { Category = Core.Enums.ProductCategories.MiesoWedliny, Product = "Szynka", Quantity = 100 });
                return PartialView("_ShoppingList", new ShoppingListDTO() { Products = products });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
