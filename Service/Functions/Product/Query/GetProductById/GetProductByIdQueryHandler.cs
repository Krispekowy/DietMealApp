using AutoMapper;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Query
{
    public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetByID(request.Id);
            return _mapper.Map<ProductDTO>(result);
        }
    }
}
