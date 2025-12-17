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
    public class CreateOrderCommandHandler(
        IRepository<Order> _orderRepository,
        IRepository<OrderProduct> _orderProductRepository,
        IRepository<Basket> _basketRepository,
        IRepository<BasketItem> _basketItemRepository,
        IRepository<Product> _productRepository) : IRequestHandler<CreateOrderCommand>
    {
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByFilterAsync(x => x.UserId == request.UserId);
            if (basket is null) throw new Exception("Sepet bulunamadı.");

            var basketItems = await _basketItemRepository.GetListByFilterAsync(x => x.BasketId == basket.Id);
            if (!basketItems.Any()) throw new Exception("Sepetinizde ürün bulunamadı.");

            var order = new Order
            {
                UserId = request.UserId,
                TotalAmount = 0
            };
            await _orderRepository.CreateAsync(order);

            foreach (var item in basketItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product is null) throw new Exception($"Ürün bulunamadı. Ürün Id={item.Id}");

                order.TotalAmount += product.Price * item.Quantity;

                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id
                };

                await _orderProductRepository.CreateAsync(orderProduct);
            }

            //Burayı HardDelete'e çevirebiliriz.
            _basketItemRepository.DeleteRange(basketItems);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
