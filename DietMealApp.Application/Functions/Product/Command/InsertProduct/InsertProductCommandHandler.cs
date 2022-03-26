using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
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
    public class InsertProductCommandHandler : BaseRequestHandler<InsertProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public InsertProductCommandHandler(
            IProductRepository productRepository,
            IMediator mediator,
            IFileManager fileManager) : base (mediator,fileManager) 
        {
            _productRepository = productRepository;
        }
        public override async Task<Unit> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Product.Photo != null)
            {
                (request.Product.PhotoFullPath, request.Product.Photo150x150Path) = await _fileManager.SendFileToFtp(request.Product.Photo, Core.Enums.ImageType.Product);
            }
            var product = Product.CreateFromDto(request.Product);
            _productRepository.Insert(product);
            await _productRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
