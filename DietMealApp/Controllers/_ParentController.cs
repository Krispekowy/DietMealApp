﻿using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace DietMealApp.WebClient.Controllers
{
    public class _ParentController : Controller
    {
        
        protected readonly IConfiguration _configuration;
        protected readonly IMediator _mediator;
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

        public _ParentController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
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
