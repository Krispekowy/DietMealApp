using DietMealApp.Core.Entities;
using DietMealApp.Core.Services;
using DietMealApp.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class HomeController : _ParentController
    {
        public HomeController(
            IConfiguration configuration, 
            RestClient restClient, 
            AppUsersDbContext appUsersDbContext, 
            UserManager<AppUser> userManager) 
            : base(configuration, 
                  restClient, 
                  appUsersDbContext, 
                  userManager)
        {
        }

        public IActionResult Index()
        {
            InitId();
            var sender = _senderId;
            return View();
        }
    }
}
