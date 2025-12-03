using HelloWorld.Application.Features.Commands.ProductCommands;
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
    public class CreateProductCommandHandler(IRepository<Product> _productRepository) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new();
            product=request.Adapt<Product>();
            await _productRepository.CreateAsync(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
