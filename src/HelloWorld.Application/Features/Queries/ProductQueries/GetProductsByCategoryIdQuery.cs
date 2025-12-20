using HelloWorld.Application.Features.Results.ProductResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Queries.ProductQueries
{
    public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<GetProductsQueryResult>>
    {
        public string CategoryId { get; set; }

        public GetProductsByCategoryIdQuery(string categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
