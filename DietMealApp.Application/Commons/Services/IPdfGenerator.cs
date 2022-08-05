using DietMealApp.Core.DTO.Menu;
using DietMealApp.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services
{
    public interface IPdfGenerator
    {
        (MemoryStream, string, string) Generate();
        MemoryStream CreateTablePDF<T>(List<T> listOfElements);
        (MemoryStream, string) GenerateMenu(List<MenuDay> menu);
    }
}
