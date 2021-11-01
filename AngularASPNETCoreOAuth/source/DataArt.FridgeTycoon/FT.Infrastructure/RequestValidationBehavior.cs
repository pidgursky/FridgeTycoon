using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FT.Queries.Productor.Get;

namespace FT.Infrastructure
{

    //TODO: use FluentValidator 
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is GetProductQuery && (request as GetProductQuery).Id == Guid.Empty)
            {
                throw new Exception("Id could not be emty.");
            }
           
            return next();
        }
    }
}
