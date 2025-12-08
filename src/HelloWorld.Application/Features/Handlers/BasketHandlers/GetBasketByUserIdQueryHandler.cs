using HelloWorld.Application.Features.Queries.BasketQueries;
using HelloWorld.Application.Features.Results.BasketResults;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.BasketHandlers
{
    public class GetBasketByUserIdQueryHandler(IRepository<Basket> _basketRepository) : IRequestHandler<GetBasketByUserIdQuery, GetBasketByUserIdQueryResult>
    {
        public async Task<GetBasketByUserIdQueryResult> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByFilterWithIncludeAsync(x => x.UserId == request.UserId, x=>x.BasketItems);
            if (basket is null) throw new Exception("Kişiye ait sepet bulunamadı.");

            return basket.Adapt<GetBasketByUserIdQueryResult>();
        }
    }
}