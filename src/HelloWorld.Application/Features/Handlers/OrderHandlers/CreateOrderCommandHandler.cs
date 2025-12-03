using HelloWorld.Application.Features.Commands.OrderCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler(IRepository<Order> _orderRepository, IRepository<OrderProduct> _orderProductRepository) : IRequestHandler<CreateOrderCommand>
    {
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order();
            var orderProducts = new List<OrderProduct>();

            foreach (var item in request.Products)
            {
                orderProducts.Add(new OrderProduct
                {
                    ProductId = item.Id,
                    OrderId = order.Id,
                });
                order.TotalAmount += item.Price;
            }

            order.OrderProducts = orderProducts; 
            order.UserId = request.UserId;

            await _orderRepository.CreateAsync(order);
            await _orderProductRepository.CreateRangeAsync(orderProducts);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
