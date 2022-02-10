
using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Functions.Product.Query.GetProductsBySearch;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Service.Functions.Command;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class ProductController : _ParentController
    {
        public ProductController(
            IMediator mediator
            ) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProductsQuery() { OrderBy = Core.Enums.OrderByProductOptions.ByName}) ;
                return View(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new ProductDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(new InsertProductCommand() { Product = model });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery() { Id = id});
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDTO productDTO)
        {
            await _mediator.Send(new DeleteProductCommand() { Id = productDTO.Id });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateProductCommand() { Product = productDTO });
                return RedirectToAction("Index");
            }
            else
            {
                return View(productDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsBySearchQuery([FromQuery] string query = "")
        {
            var productsList = await _mediator.Send(new GetProductsBySearchQuery() { Query = query });
            return Json(productsList);
        }
    }
}
