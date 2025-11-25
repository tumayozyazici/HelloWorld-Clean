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
    public class GetProductByIdQueryHandler(IRepository<Product> _productRepository) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product =  await _productRepository.GetByIdAsync(request.Id);
            return new GetProductByIdQueryResult
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                InStock = product.InStock,
                CategoryId = product.CategoryId,
                Status = product.Status.ToString()
            };
        }
    }
}