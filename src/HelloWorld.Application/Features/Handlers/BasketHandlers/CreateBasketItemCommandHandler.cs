using HelloWorld.Application.Features.Commands.BasketCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.BasketHandlers
{
    public class CreateBasketItemCommandHandler(IRepository<Basket> _basketRepository, IRepository<BasketItem> _basketItemRepository) : IRequestHandler<CreateBasketItemCommand>
    {
        public async Task Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByFilterASync(x => x.UserId == request.UserId);

            if (basket is null)
            {
                basket = new Basket
                {
                    UserId = request.UserId
                };
            }

            await _basketRepository.CreateAsync(basket);
            await _basketRepository.SaveChangesAsync();

            var existingItem = await _basketItemRepository.GetByFilterASync(x => x.BasketId == basket.Id && x.ProductId == request.ProductId);

            if (existingItem is not null)
            {
                existingItem.Quantity += request.Quantity;
                await _basketItemRepository.UpdateAsync(existingItem);
            }
            else
            {
                var newItem = new BasketItem
                {
                    BasketId = basket.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };

                await _basketItemRepository.CreateAsync(newItem);
            }

            await _basketItemRepository.SaveChangesAsync();
        }
    }
}