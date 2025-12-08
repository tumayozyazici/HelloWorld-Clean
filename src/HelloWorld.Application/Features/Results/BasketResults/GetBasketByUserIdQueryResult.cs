using HelloWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Results.BasketResults
{
    public class GetBasketByUserIdQueryResult
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public IEnumerable<BasketItem> BasketItems { get; set; }
    }
}
