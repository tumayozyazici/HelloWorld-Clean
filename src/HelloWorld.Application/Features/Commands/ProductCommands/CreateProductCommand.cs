using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.ProductCommands
{
    public class CreateProductCommand :IRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string? CategoryId { get; set; }
    }
}
