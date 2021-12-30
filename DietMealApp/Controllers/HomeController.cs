using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class HomeController : _ParentController
    {
        private readonly IFileManager _fileManager;

        public HomeController(
            IMediator mediator,
            IFileManager fileManager
            ) : base(mediator)
        {
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index()
        {
            InitId();
            //var filePath = _fileManager.GetFileFromFtp("noimage.png");
            return View("Index", model: "http://dietmealapp.cba.pl/products/shutterstock_360681410-1500px-square.jpg");
        }
    }
}
