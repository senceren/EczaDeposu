using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerId, Address shippingAddress);
        Task<List<Order>> GetAllOrdersAsync();
    }
}
