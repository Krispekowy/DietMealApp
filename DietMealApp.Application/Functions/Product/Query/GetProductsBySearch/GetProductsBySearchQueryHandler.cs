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
    public sealed class GetProductsBySearchQueryHandler : IRequestHandler<GetProductsBySearchQuery, SelectList>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsBySearchQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<SelectList> Handle(GetProductsBySearchQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.Get(p => p.ProductName.Contains(request.Query)).ToListAsync();
            return new SelectList(products, "Id", "ProductName");
        }
    }
}
