using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;
        private readonly IBasketService _basketService;

        public OrderService(IRepository<Order> orderRepo, IBasketService basketService)
        {
            _orderRepo = orderRepo;
            _basketService = basketService;
        }
        public async Task<Order> CreateOrderAsync(string buyerId, Address shippingAddress)
        {
            var basket = await _basketService.GetOrCreateBasketAsync(buyerId); // giriş yapan kişinin sepetine getir.

            Order order = new Order()
            {
                ShippingAddress = shippingAddress,
                UserId = buyerId,
                Items = basket.Items.Select(x => new OrderItem() // yeni bir sipariş oluştur ve sepettekileri bu sipariş içine ekle.
                {
                    MedicineId = x.MedicineId,
                    MedicineName = x.Medicine.Name,
                    UnitPrice = x.Medicine.Price,
                    PictureUri = x.Medicine.PictureUri,
                    Quantity = x.Quantity,
                }).ToList()
            };

            return await _orderRepo.AddAsync(order);
        }
    }
}
