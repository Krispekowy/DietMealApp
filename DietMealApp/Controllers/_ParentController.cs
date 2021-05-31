using DietMealApp.Core.Entities;
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
        private readonly IMediator _mediator;

        public string _senderId { get; set; }

        public _ParentController(
            IConfiguration configuration,
            AppUsersDbContext appUsersDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IMediator mediator
            )
        {
            _configuration = configuration;
            _appUsersDbContext = appUsersDbContext;
            _userManager = userManager;
            _mediator = mediator;
        }

        public _ParentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public _ParentController(IConfiguration configuration, AppUsersDbContext appUsersDbContext, UserManager<AppUser> userManager)
        {
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
