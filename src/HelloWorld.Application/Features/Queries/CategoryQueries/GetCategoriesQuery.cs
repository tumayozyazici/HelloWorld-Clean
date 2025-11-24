using HelloWorld.Application.Features.Results.CategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Queries.CategoryQueries
{
    public class GetCategoriesQuery: IRequest<IEnumerable<GetCategoriesQueryResult>>
    {
    }
}
