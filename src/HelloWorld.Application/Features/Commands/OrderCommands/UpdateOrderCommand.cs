using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest
    {
        public UpdateOrderCommand()
        {
            Products = new List<Product>();
        }
        public string Id { get; set; }
        public string? UserId { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
