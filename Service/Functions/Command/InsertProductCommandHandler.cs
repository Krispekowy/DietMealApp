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
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public InsertProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Unit> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.Insert(Product.GetProductFromDTO(request.Product));
            _productRepository.CommitAsync();
            return Task.FromResult(Unit.Value);
        }
    }
}
