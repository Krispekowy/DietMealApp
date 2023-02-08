using DietMealApp.Core.DTO.Menu;
using DietMealApp.Core.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.PDFGenerator.Query.GetMenu
{
    public class GetMenuPDFQuery : IRequest<(MemoryStream, string)>
    {
        public List<MenuDay> MenuDays { get; set; }
    }

}
