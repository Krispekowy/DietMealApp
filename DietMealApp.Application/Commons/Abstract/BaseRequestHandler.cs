using AutoMapper;
using DietMealApp.Application.Commons.Services.FileManager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Abstract
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly IFileManager _fileManager;

        protected BaseRequestHandler(IMediator mediator, IFileManager fileManager)
        {
            _mediator = mediator;
            _fileManager = fileManager;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class BaseRequestHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        protected readonly IMediator _mediator;
        protected readonly IFileManager _fileManager;

        protected BaseRequestHandler(IMediator mediator, IFileManager fileManager)
        {
            _mediator = mediator;
            _fileManager = fileManager;
        }
        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
