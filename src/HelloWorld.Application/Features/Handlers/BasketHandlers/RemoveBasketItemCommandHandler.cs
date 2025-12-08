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
    public class RemoveBasketItemCommandHandler(IRepository<Basket> _basketRepository, IRepository<BasketItem> _basketItemRepository) : IRequestHandler<RemoveBasketItemCommand>
    {
        public async Task Handle(RemoveBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByFilterASync(x => x.UserId == request.UserId);
            if (basket is null) return;

            var existingItem = await _basketItemRepository.GetByFilterASync(x => x.BasketId == basket.Id && x.ProductId == request.ProductId);
            if (existingItem is null) return;

            existingItem.Quantity -= request.Quantity;

            if (existingItem.Quantity <= 0) await _basketItemRepository.DeleteAsync(existingItem.Id);
            else await _basketItemRepository.UpdateAsync(existingItem);

            await _basketItemRepository.SaveChangesAsync();
        }
    }
}
