using HelloWorld.Application.Features.Queries.UserQueries;
using HelloWorld.Application.Features.Results.UserResults;
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
    public class GetUserByIdQueryHandler(IRepository<User> _userRepository) : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            return new GetUserByIdQueryResult
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                BirthDate = user.BirthDate,
                BillingAdress = user.BillingAdress,
                ShippingAdress = user.ShippingAdress,
                Status = user.Status.ToString()
            };
        }
    }
}
