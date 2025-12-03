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
    public class RemoveProductCommandHandler(IRepository<Product> _productRepository) : IRequestHandler<RemoveProductCommand>
    {
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);
            await _productRepository.SaveChangesAsync();
        }
    }
}
