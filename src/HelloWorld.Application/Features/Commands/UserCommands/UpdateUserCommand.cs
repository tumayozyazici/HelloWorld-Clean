using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string? BillingAdress { get; set; }
        public string? ShippingAdress { get; set; }
    }
}
