using HelloWorld.Domain.Abstracts;
using HelloWorld.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;


        public HashSet<OrderProduct>? OrderProducts { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}