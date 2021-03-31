using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class DietDayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
