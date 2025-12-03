using HelloWorld.Application.Features.Commands.OrderCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler(IRepository<Order> _orderRepository, IRepository<OrderProduct> _orderProductRepository) : IRequestHandler<UpdateOrderCommand>
    {
        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            order.TotalAmount = 0;
            var orderProducts = await _orderProductRepository.GetListByFilterAsync(op => op.OrderId == request.Id && op.Status != EntityStatus.Deleted);
            _orderProductRepository.DeleteRange(orderProducts);

            var newOrderProducts = new List<OrderProduct>();
            foreach (var item in request.Products)
            {

                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = item.Id
                };
                order.TotalAmount += item.Price;
            }

            order.OrderProducts = newOrderProducts;
            order.UserId = request.UserId;

            await _orderProductRepository.CreateRangeAsync(newOrderProducts);
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
