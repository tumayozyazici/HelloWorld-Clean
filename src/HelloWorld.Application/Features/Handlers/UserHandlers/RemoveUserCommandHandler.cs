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
    public class RemoveUserCommandHandler(IRepository<User> _userRepository) : IRequestHandler<RemoveUserCommand>
    {
        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.Id);
            await _userRepository.SaveChangesAsync();
        }
    }
}
