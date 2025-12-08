using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.BasketCommands
{
    public class ClearBasketCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
