using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public class ProductOrderEntity 
    {
        public Guid ProductCode { get; set; }
        public Guid OrderCode { get; set; }
        public int Number { get; set; }
        public double PriceForSale { get; set; }
        public byte PromotionForSale { get; set; }

        public OrderEntity Orders { get; set; }
        public ProductEntity Products { get; set; }
    }
}
