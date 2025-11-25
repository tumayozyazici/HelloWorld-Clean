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
    public class UpdateProductCommandHandler(IRepository<Product> _productRepository) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.InStock = request.InStock;
            product.CategoryId = request.CategoryId;
            await _productRepository.UpdateAsync(product);
        }
    }
}
