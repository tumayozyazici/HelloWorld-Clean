using HelloWorld.Application.Features.Queries.ProductQueries;
using HelloWorld.Application.Features.Results.ProductResults;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.ProductHandlers
{
    public class GetProductsByCategoryIdQueryHandler(IRepository<Product> _productRepository) : IRequestHandler<GetProductsByCategoryIdQuery, IEnumerable<GetProductsByCategoryIdQueryResult>>
    {
        public async Task<IEnumerable<GetProductsByCategoryIdQueryResult>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListByFilterAsync(x => x.CategoryId == request.CategoryId);

            return products.Adapt<IEnumerable<GetProductsByCategoryIdQueryResult>>();
        }
    }
}
