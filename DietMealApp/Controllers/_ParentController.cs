using DietMealApp.Core.Entities;
using DietMealApp.Core.Services;
using DietMealApp.DataAccessLayer;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class _ParentController : Controller
    {
        
        protected readonly IConfiguration _configuration;
        private readonly AppUsersDbContext _appUsersDbContext;
        private readonly UserManager<AppUser> _userManager;

        public string _senderId { get; set; }

        public _ParentController(
            IConfiguration configuration,
            AppUsersDbContext appUsersDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _configuration = configuration;
            _appUsersDbContext = appUsersDbContext;
            _userManager = userManager;
        }

        public _ParentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected void InitId()
        {
            if (User != null)//umieszczone tutaj bo scope 
            {
                _senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}
