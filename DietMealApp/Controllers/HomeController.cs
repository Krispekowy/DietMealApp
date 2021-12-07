using DietMealApp.Application.Commons.Services;
using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class HomeController : _ParentController
    {
        public HomeController(
            IMediator mediator
            ) : base(mediator)
        {
        }

        public async Task<IActionResult> Index()
        {
            InitId();
            return View();
        }
    }
}
