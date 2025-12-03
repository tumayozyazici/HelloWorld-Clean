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
    public class CreateOrderCommand : IRequest
    {
        public CreateOrderCommand()
        {
            Products = new List<Product>();
        }
        public string? UserId { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
