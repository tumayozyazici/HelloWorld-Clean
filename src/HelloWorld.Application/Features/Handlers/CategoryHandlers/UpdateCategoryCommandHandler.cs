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
    public class UpdateCategoryCommandHandler(IRepository<Category> _categoryRepository) : IRequestHandler<UpdateCategoryCommand>
    {
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category is null) throw new Exception("Kategori bulunamadı");
            category.CategoryName = request.CategoryName;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
