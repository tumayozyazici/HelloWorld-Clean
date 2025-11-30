using HelloWorld.Application.Features.Commands.UserCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Handlers.UserHandlers
{
    public class CreateUserCommandHandler(IRepository<User> _userRepository) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user = request.Adapt<User>();
            user.SetPassword(request.Password);
            await _userRepository.CreateAsync(user);
        }
    }
}
