using HelloWorld.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Features.Results.CategoryResults
{
    public class GetCategoriesQueryResult
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
    }
}
