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
    public class GetOrderByIdQueryHandler(IRepository<Order> _orderRepository, IRepository<OrderProduct> _orderProductRepository) : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order is null) throw new Exception("Sipariş bulunamadı");

            return order.Adapt<GetOrderByIdQueryResult>();
        }
    }
}
