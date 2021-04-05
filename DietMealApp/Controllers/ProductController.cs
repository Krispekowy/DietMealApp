using DietMealApp.Core.Services;
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
        public ProductController(IConfiguration configuration, RestClient restClient) 
            : base(configuration, restClient) { }

        public async Task<IActionResult> Index()
        {
            //await _RestClient.RequestAsync($"Products/GetAll", HttpMethod.Get, "", _SenderId);
            if (!_RestClient.IsSuccessful || String.IsNullOrEmpty(_RestClient.ResponseMessage))
            {
                return StatusCode(500);
            }
            //var products = JsonConvert.DeserializeObject
            return View();
        }
    }
}
