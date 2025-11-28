using HelloWorld.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public HashSet<OrderProduct>? OrderProducts { get; set; }
    }
}
