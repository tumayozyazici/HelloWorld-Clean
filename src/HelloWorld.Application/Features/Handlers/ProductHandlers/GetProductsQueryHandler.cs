using HelloWorld.Application.Features.Queries.ProductQueries;
using HelloWorld.Application.Features.Results.ProductResults;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(IRepository<Product> _productRepository) : IRequestHandler<GetProductsQuery, IEnumerable<GetProductsQueryResult>>
    {
        public async Task<IEnumerable<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new GetProductsQueryResult
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                InStock = p.InStock,
                CategoryId = p.CategoryId,
                Status = p.Status.ToString()
            });
        }
    }
}
