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
    public class UpdateUserCommandHandler(IRepository<User> _userRepository) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            user.FirstName = request.FirstName;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PasswordHash = request.PasswordHash;
            user.BirthDate = request.BirthDate;
            user.BillingAdress = request.BillingAdress;
            user.ShippingAdress = request.ShippingAdress;
            await _userRepository.UpdateAsync(user);
        }
    }
}
