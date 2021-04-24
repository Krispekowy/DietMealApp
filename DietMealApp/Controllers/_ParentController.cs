using DietMealApp.Core.Entities;
using DietMealApp.Core.Services;
using DietMealApp.DataAccessLayer;
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
        protected readonly RestClient _restClient;
        private readonly AppUsersDbContext _appUsersDbContext;
        private readonly UserManager<AppUser> _userManager;
        public string _senderId { get; set; }

        public _ParentController(
            IConfiguration configuration,
            RestClient restClient,
            AppUsersDbContext appUsersDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _configuration = configuration;
            _restClient = restClient;
            _appUsersDbContext = appUsersDbContext;
            _userManager = userManager;
        }

        public _ParentController(IConfiguration configuration, RestClient restClient)
        {
            _configuration = configuration;
            _restClient = restClient;
        }

        public _ParentController(IConfiguration configuration, RestClient restClient, AppUsersDbContext appUsersDbContext, UserManager<AppUser> userManager) : this(configuration, restClient)
        {
        }

        protected void InitId()
        {
            if (User != null)//umieszczone tutaj bo scope 
            {
                _senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
        //public async Task<bool> UserHasCompleatedContract()
        //{
        //    var user = await _ApplicationUserMannager.GetUserAsync(User);
        //    return user.UserHasCompleatedContract;
        //}
        //public async Task<bool> UserHasElectroniclySignedContract()
        //{
        //    var user = await _ApplicationUserMannager.GetUserAsync(User);
        //    return user.UserHasElectroniclySignedContract;
        //}
        //public async Task<bool> UserHasLabel()
        //{
        //    var user = await _ApplicationUserMannager.GetUserAsync(User);
        //    return user.UserHasLabel;
        //}

        //public async Task<bool> UserCompleadedOfferPref()
        //{
        //    var user = await _ApplicationUserMannager.GetUserAsync(User);
        //    return user.CompleatedOfferPreferencesForm;
        //}
    }
}
