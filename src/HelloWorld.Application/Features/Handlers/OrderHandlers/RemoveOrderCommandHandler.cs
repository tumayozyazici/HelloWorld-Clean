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
    public class RemoveOrderCommandHandler(IRepository<Order> _orderRepository, IRepository<OrderProduct> _orderProductRepository) : IRequestHandler<RemoveOrderCommand>
    {
        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var orderProducts = await _orderProductRepository.GetListByFilterAsync(x => x.OrderId == request.Id && x.Status != EntityStatus.Deleted);

            _orderProductRepository.DeleteRange(orderProducts);
            await _orderRepository.DeleteAsync(request.Id);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
