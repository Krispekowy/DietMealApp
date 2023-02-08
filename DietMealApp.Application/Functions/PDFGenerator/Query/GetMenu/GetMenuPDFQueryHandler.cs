using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.PDFGenerator.Query.GetMenu
{
    public class GetMenuPDFQueryHandler : BaseRequestHandler<GetMenuPDFQuery, (MemoryStream, string)>
    {
        private readonly IPdfGenerator _pdfGenerator;

        public GetMenuPDFQueryHandler(IMediator mediator, IFileManager fileManager, IPdfGenerator pdfGenerator) : base(mediator, fileManager)
        {
            _pdfGenerator = pdfGenerator;
        }

        public override async Task<(MemoryStream, string)> Handle(GetMenuPDFQuery request, CancellationToken cancellationToken)
        {
            return _pdfGenerator.GenerateMenu(request.MenuDays);
        }
    }
}
