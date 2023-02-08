using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class HomeController : _ParentController
    {
        private readonly IFileManager _fileManager;
        private readonly IPdfGenerator _pdfGenerator;

        public HomeController(
            IMediator mediator,
            IFileManager fileManager,
            IPdfGenerator pdfGenerator,
            IDeviceDetector deviceDetector
            ) : base(mediator, deviceDetector)
        {
            _fileManager = fileManager;
            _pdfGenerator = pdfGenerator;
        }

        public async Task<IActionResult> Index()
        {
            InitId();
            //var filePath = _fileManager.GetFileFromFtp("noimage.png");
            return View("Index", model: "http://dietmealapp.cba.pl/products/shutterstock_360681410-1500px-square.jpg");
        }

        public async Task<IActionResult> GeneratePDF()
        {
            var list = new List<ProductsToBuyDTO>();
            list.Add(new ProductsToBuyDTO() { Product = "Nowy produkt", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "Nowy", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "produkt", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "Szynka", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "Jeszcze coś", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "Marchew", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "dupa", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            list.Add(new ProductsToBuyDTO() { Product = "kleik", Quantity = 100, Category = Core.Enums.ProductCategories.Owoce });
            var stream = _pdfGenerator.CreateTablePDF(list);
            return File(stream, "application/pdf","ListaZakupow.pdf");
        }
    }
}
