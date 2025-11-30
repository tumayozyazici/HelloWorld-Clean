using HelloWorld.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public DateTimeOffset BirthDate { get; set; }
        public string? BillingAdress { get; set; }
        public string? ShippingAdress { get; set; }
        public HashSet<Order>? Orders { get; set; }

        public void SetPassword(string password)
        {
            using var hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public bool VerifyPassword(string password)
        {
            using var hmac = new HMACSHA512(PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(PasswordHash);
        }
    }
}
