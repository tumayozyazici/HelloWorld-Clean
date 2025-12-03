using HelloWorld.Application.Features.Commands.CategoryCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> _categoryRepository) : IRequestHandler<RemoveCategoryCommand>
    {
        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(request.Id);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
