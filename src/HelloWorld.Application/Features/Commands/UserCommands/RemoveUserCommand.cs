using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.UserCommands
{
    public class RemoveUserCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveUserCommand(string id)
        {
            Id = id;
        }
    }
}
