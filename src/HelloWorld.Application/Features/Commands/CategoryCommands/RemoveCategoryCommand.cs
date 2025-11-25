using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveCategoryCommand(string id)
        {
            Id = id;
        }
    }
}
