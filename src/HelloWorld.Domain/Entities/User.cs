using HelloWorld.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string? BillingAdress { get; set; }
        public string? ShippingAdress { get; set; }
        public HashSet<Order> Orders { get; set; }
    }
}
