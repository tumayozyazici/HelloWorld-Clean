using HelloWorld.Application.Features.Commands.ProductCommands;
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
    public class CreateProductCommandHandler(IRepository<Product> _productRepository) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new();
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.InStock = request.InStock;
            product.CategoryId = request.CategoryId;
            await _productRepository.CreateAsync(product);
        }
    }
}
