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
    public class GetBasketByIdQueryHandler(IRepository<Basket> _basketRepository) : IRequestHandler<GetBasketByIdQuery, GetBasketByIdQueryResult>
    {
        public async Task<GetBasketByIdQueryResult> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByFilterWithIncludeAsync(x => x.Id == request.Id, x => x.BasketItems);
            if (basket is null) throw new Exception("Kişiye ait sepet bulunamadı.");

            return basket.Adapt<GetBasketByIdQueryResult>();
        }
    }
}
