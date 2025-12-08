using HelloWorld.Application.Features.Queries.OrderQueries;
using HelloWorld.Application.Features.Results.OrderResults;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.OrderHandlers
{
    public class GetOrdersQueryHandler(IRepository<OrderProduct> _orderProductRepository, IRepository<Order> _orderRepository) : IRequestHandler<GetOrdersQuery, IEnumerable<GetOrdersQueryResult>>
    {
        public async Task<IEnumerable<GetOrdersQueryResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            if(!orders.Any() || orders is null) throw new Exception("Hiç sipariş bulunamadı.");

            return orders.Adapt<IEnumerable<GetOrdersQueryResult>>();
        }
    }
}
