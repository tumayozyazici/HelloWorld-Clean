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
    public class GetUsersQueryHandler(IRepository<User> _userRepository) : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersQueryResult>>
    {
        public async Task<IEnumerable<GetUsersQueryResult>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new GetUsersQueryResult
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
            });
        }
    }
}
