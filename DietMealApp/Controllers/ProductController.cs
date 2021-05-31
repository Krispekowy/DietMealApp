using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Service;
using DietMealApp.Service.Functions.Command;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class ProductController : _ParentController
    {
        private readonly IMediator _mediator;

        public ProductController(
            IConfiguration configuration,
            IMediator mediator)
            : base(configuration)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IndexProductDTO>> Index()
        {
            try
            {
                var request = new GetAllProductsQuery
                {
                    OrderBy = Core.Enums.OrderByProductOptions.ByName
                };
                var result = await _mediator.Send(request);
                return View(new IndexProductDTO()
                {
                    Products = IndexProductDTO.ProductEntityToDTO(result)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductDTO();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            try
            {
                var request = new InsertProductCommand
                {
                    Product = model
                };
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new GetProductByIdQuery
            {
                Id = id
            };
            var result = await _mediator.Send(request);
            var productDTO = ProductDTO.ProductEntityToDTO(result);
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDTO productDTO)
        {
            var request = new DeleteProductCommand
            {
                Id = productDTO.Id
            };
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }
    }
}
