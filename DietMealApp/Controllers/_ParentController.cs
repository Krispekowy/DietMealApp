using DietMealApp.Application.Commons.Services;
using DietMealApp.Core.Entities;
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
        
        protected readonly IMediator _mediator;
        private readonly AppUsersDbContext _appUsersDbContext;
        private readonly UserManager<AppUser> _userManager;

        public string _senderId { get; set; }

        public _ParentController(
            AppUsersDbContext appUsersDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _appUsersDbContext = appUsersDbContext;
            _userManager = userManager;
        }

        public _ParentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected void InitId()
        {
            if (User != null)
            {
                _senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}
