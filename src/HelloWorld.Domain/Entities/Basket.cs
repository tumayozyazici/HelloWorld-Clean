using HelloWorld.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }

        public string UserId { get; set; } = null!;


        public IEnumerable<BasketItem> BasketItems { get; set; }
    }
}
