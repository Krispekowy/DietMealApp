using DietMealApp.Core.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.PDFGenerator.Query.GetShoppingList
{
    public class GetShoppingListPDFQuery : IRequest<(MemoryStream, string)>
    {
        public List<ShoppingListPdfViewModel> ListOfProducts { get; set; }
    }
}
