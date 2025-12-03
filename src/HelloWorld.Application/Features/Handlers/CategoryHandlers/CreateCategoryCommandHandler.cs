using HelloWorld.Application.Features.Commands.CategoryCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler(IRepository<Category> _categoryRepository) : IRequestHandler<CreateCategoryCommand>
    {
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new();
            category = request.Adapt<Category>();
            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
