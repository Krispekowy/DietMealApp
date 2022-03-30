using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO.Products;
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
    public class GetAllProductsQueryHandler : BaseRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(
            IProductRepository productRepository,
            IMediator mediator,
            IFileManager fileManager) : base (mediator, fileManager)
        {
            _productRepository = productRepository;
        }
        public override async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<Product>();

            if (request.OrderBy == Core.Enums.OrderByProductOptions.ByCategory)
            {
                result = await _productRepository.Get().OrderBy(a => a.Category).ToListAsync();
            }
            if (request.OrderBy == Core.Enums.OrderByProductOptions.ByKcal)
            {
                result = await _productRepository.Get().OrderBy(a => a.Kcal).ToListAsync();
            }
            if (request.OrderBy == Core.Enums.OrderByProductOptions.ByName)
            {
                result = await _productRepository.Get().OrderBy(a => a.ProductName).ToListAsync();
            }
            if (request.OrderBy == Core.Enums.OrderByProductOptions.None)
            {
                result = await _productRepository.Get().ToListAsync();
            }

            return result.Select(x => ProductDTO.CreateFromEntity(x)).ToList();
        }
    }
}
