using HelloWorld.Application.Features.Results.OrderResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        public string Id { get; set; }

        public GetOrderByIdQuery(string id)
        {
            Id = id;
        }
    }
}
