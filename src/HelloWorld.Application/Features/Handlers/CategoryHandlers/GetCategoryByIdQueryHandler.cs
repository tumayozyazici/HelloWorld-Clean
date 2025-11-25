using HelloWorld.Application.Features.Queries.CategoryQueries;
using HelloWorld.Application.Features.Results.CategoryResults;
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
    public class GetCategoryByIdQueryHandler(IRepository<Category> _categoryRepository) : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            return new GetCategoryByIdQueryResult
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Status = category.Status.ToString()
            };
        }
    }
}
