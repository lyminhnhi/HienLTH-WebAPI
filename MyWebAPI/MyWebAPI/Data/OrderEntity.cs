using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public class OrderEntity
    {
        public enum Status
        {
            New = 0, Paymented = 1, Complete = 2, Cancel = -1
        }
        public Guid OrderCode { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public Status StatusOrder { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAdress { get; set; }
        public string RecipientPhone { get; set; }

        public ICollection<ProductOrderEntity> ProductOrders { get; set; }

        public OrderEntity()
        {
            ProductOrders = new List<ProductOrderEntity>();
        }
    }
}
