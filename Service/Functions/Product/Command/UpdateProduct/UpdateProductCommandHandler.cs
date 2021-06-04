using AutoMapper;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Service.Functions.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);
            _productRepository.Update(product);
            await _productRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
