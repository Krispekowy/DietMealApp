using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Product.Query.GetProductsBySearch
{
    public sealed class GetProductsBySearchQueryHandler : BaseRequestHandler<GetProductsBySearchQuery, SelectList>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsBySearchQueryHandler(
            IProductRepository productRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _productRepository = productRepository;
        }

        public override async Task<SelectList> Handle(GetProductsBySearchQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.Get(p => p.ProductName.Contains(request.Query)).ToList();
            return new SelectList(products, "Id", "ProductName");
        }
    }
}
