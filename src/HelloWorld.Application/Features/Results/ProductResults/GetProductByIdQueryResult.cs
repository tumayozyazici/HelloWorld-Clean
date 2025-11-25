using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Results.ProductResults
{
    public class GetProductByIdQueryResult
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string? CategoryId { get; set; }
        public string Status { get; set; }

    }
}
