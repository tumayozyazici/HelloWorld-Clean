using HelloWorld.Application.Features.Commands.UserCommands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
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
            user.FirstName = request.FirstName;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PasswordHash = request.PasswordHash;
            user.BirthDate = request.BirthDate;
            await _userRepository.CreateAsync(user);
        }
    }
}
