﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IFileManager _fileManager;

        public InsertProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IMediator mediator,
            IFileManager fileManager) : base (mediator,mapper,fileManager) 
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
            _fileManager = fileManager;
        }
        public override async Task<Unit> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var paths = await _fileManager.SendFileToFtp(request.Product.Photo, Core.Enums.ImageType.Product);
            request.Product.PhotoFullPath = paths.Item1;
            request.Product.Photo150x150Path = paths.Item2;
            var product = _mapper.Map<Product>(request.Product);
            _productRepository.Insert(product);
            await _productRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
