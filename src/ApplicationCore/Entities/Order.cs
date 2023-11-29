using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public List<OrderItem> Items { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Address ShippingAddress { get; set; }
    }
}
