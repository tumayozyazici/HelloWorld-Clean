using HelloWorld.Application.Features.Commands.OrderCommands;
using HelloWorld.Application.Features.Queries.OrderQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            if (!orders.Any()) return NotFound("Hiç Sipariş Bululamadı");
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            if (order is null) return NotFound("Sipariş Bulunamadı");
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş Başarıyla Oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Sipariş Başarıyla Silindi");
        }
    }
}
