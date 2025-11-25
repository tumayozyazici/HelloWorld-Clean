using HelloWorld.Application.Features.Queries.CategoryQueries;
using HelloWorld.Application.Features.Results.CategoryResults;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler(IRepository<Category> _categoryRepository) : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoriesQueryResult>>
    {
        public async Task<IEnumerable<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new GetCategoriesQueryResult
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                Status = c.Status.ToString()
            });
        }
    }
}
