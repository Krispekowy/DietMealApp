using DietMealApp.Core.DTO;
using DietMealApp.Service;
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
        private readonly IProductService _productService;

        public ProductController(
            IConfiguration configuration,
            IProductService productService) 
            : base(configuration)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.Index();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _productService.Create();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            await _productService.Create(model);
            return View("Index");

        }
    }
}
