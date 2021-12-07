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
        protected readonly IMediator _Mediator;

        protected BaseRequestHandler(IMediator mediator)
        {
            _Mediator = mediator;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class BaseRequestHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        protected readonly IMediator _Mediator;

        protected BaseRequestHandler(IMediator mediator)
        {
            _Mediator = mediator;
        }
        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
