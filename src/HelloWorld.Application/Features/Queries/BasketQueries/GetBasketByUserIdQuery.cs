using HelloWorld.Application.Features.Results.BasketResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Queries.BasketQueries
{
    public class GetBasketByUserIdQuery:IRequest<GetBasketByUserIdQueryResult>
    {
        public string UserId { get; set; }

        public GetBasketByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
