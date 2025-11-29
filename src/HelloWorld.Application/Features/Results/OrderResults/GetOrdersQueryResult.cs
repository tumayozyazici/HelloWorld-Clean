using HelloWorld.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Results.OrderResults
{
    public class GetOrdersQueryResult
    {
        public string Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string? UserId { get; set; }

        //Burada bir product listesi de olacak mı bilmiyoruz. senaryoya göre eklenebilir.
    }
}
