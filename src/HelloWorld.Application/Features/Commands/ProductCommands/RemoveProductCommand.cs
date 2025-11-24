using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveProductCommand(string id)
        {
            Id = id;
        }
    }
}
