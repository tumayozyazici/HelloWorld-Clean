using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.OrderCommands
{
    public class RemoveOrderCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveOrderCommand(string id)
        {
            Id = id;
        }
    }
}
