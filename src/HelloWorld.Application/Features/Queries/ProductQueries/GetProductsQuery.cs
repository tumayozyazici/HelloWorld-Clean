using HelloWorld.Application.Features.Results.ProductResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Queries.ProductQueries
{
    public class GetProductsQuery : IRequest<IEnumerable<GetProductsQueryResult>>
    {
    }
}
