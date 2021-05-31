using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Query
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            switch (request.OrderBy)
            {
                case Core.Enums.OrderByProductOptions.None:
                    return await _productRepository.Get().ToListAsync();
                case Core.Enums.OrderByProductOptions.ByName:
                    return await _productRepository.Get().OrderBy(a=>a.ProductName).ToListAsync();
                case Core.Enums.OrderByProductOptions.ByCategory:
                    return await _productRepository.Get().OrderBy(a => a.Category).ToListAsync();
                case Core.Enums.OrderByProductOptions.ByKcal:
                    return await _productRepository.Get().OrderBy(a => a.Kcal).ToListAsync();
                default:
                    return await _productRepository.Get().ToListAsync();
            }
            
        }
    }
}
