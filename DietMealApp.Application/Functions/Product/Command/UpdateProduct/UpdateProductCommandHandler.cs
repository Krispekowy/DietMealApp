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
    public class UpdateProductCommandHandler : BaseRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, mapper, fileManager)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public override async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Product.Photo != null)
            {
                request.Product.PhotoPath = await _fileManager.SendFileToFtp(request.Product.Photo, FtpPathRepository.FtpProductFull);
            }
            var product = _mapper.Map<Product>(request.Product);
            _productRepository.Update(product);
            await _productRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
