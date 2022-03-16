using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class ProductDto : ProductVMDto
    {
        public Guid ProductCode { get; set; }
    }
}
