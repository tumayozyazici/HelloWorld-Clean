using HelloWorld.Application.Features.Results.BasketResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Queries.BasketQueries
{
    public class GetBasketByIdQuery : IRequest<GetBasketByIdQueryResult>
    {
        public string Id { get; set; }

        public GetBasketByIdQuery(string id)
        {
            Id = id;
        }
    }
}
