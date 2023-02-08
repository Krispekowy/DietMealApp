using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.PDFGenerator.Query.GetShoppingList
{
    public class GetShoppingListPDFQueryHandler : BaseRequestHandler<GetShoppingListPDFQuery, (MemoryStream, string)>
    {
        private readonly IPdfGenerator _pdfGenerator;

        public GetShoppingListPDFQueryHandler(IMediator mediator, IFileManager fileManager, IPdfGenerator pdfGenerator) : base(mediator, fileManager)
        {
            _pdfGenerator = pdfGenerator;
        }

        public override async Task<(MemoryStream, string)> Handle(GetShoppingListPDFQuery request, CancellationToken cancellationToken)
        {
            return _pdfGenerator.GenerateShoppingList(request.ListOfProducts);
        }
    }
}