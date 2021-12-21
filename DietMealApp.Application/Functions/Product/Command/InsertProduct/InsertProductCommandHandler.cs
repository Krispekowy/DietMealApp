using AutoMapper;
using DietMealApp.Application.Commons.Services.FileManager;
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
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public InsertProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IFileManager fileManager)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public Task<Unit> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            _fileManager.UploadFileToFtp();
            var product = _mapper.Map<Product>(request.Product);
            _productRepository.Insert(product);
            _productRepository.CommitAsync();
            return Task.FromResult(Unit.Value);
        }
    }
}
