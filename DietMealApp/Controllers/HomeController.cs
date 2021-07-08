using DietMealApp.Core.Entities;
using DietMealApp.Core.Services;
using DietMealApp.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class HomeController : _ParentController
    {
        public HomeController(
            IConfiguration configuration,
            AppUsersDbContext appUsersDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
            : base(configuration, 
                  appUsersDbContext,
                  userManager,
                  signInManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            InitId();
            return View();
        }
    }
}
