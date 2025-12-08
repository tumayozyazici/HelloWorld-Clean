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
    public class ClearBasketCommandHandler(IRepository<Basket> _basketRepository, IRepository<BasketItem> _basketItemRepository) : IRequestHandler<ClearBasketCommand>
    {
        public async Task Handle(ClearBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByFilterASync(x => x.UserId == request.UserId);
            if (basket is null) return;

            var items = await _basketItemRepository.GetListByFilterAsync(x => x.BasketId == basket.Id);

            _basketItemRepository.DeleteRange(items);
            await _basketItemRepository.SaveChangesAsync();
        }
    }
}
