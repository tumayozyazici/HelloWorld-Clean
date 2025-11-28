using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Results.UserResults
{
    public class GetUsersQueryResult
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string? BillingAdress { get; set; }
        public string? ShippingAdress { get; set; }
        public string Status { get; set; }
    }
}
