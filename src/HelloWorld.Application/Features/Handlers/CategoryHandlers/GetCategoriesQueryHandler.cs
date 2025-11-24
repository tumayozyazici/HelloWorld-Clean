using HelloWorld.Application.Features.Queries.CategoryQueries;
using HelloWorld.Application.Features.Results.CategoryResults;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler : IRequestExceptionHandler<GetCategoriesQuery, IEnumerable<GetCategoriesQueryResult>>
    {
        public Task Handle(GetCategoriesQuery request, Exception exception, RequestExceptionHandlerState<IEnumerable<GetCategoriesQueryResult>> state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
