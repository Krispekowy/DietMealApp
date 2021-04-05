using DietMealApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class _ParentController : Controller
    {
        
        protected readonly IConfiguration _Configuration;
        protected readonly RestClient _RestClient;
        protected readonly string[] ALLOWED_VIDEO_EXTENSIONS = { ".avi", ".mp4", ".mov" };
        protected readonly string[] ALLOWED_IMAGE_EXTENSIONS = { ".png", ".jpg", ".jpeg" };
        protected const int MAX_IMAGE_SIZE = 2097152 * 5;//in bytes (10MB)
        public _ParentController(
            IConfiguration configuration,
            RestClient restClient
            )
        {
            _Configuration = configuration;
            _RestClient = restClient;
        }

        //protected void InitSenderId()
        //{
        //    if (User != null)//umieszczone tutaj bo scope 
        //    {
        //        _SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    }
        //}
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
