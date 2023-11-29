using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Services
{
    public class OrderViewModelService : IOrderViewModelService
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderViewModelService(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public async Task<List<OrderViewModel>> GetAllOrderAsync()
       {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderViewModels = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    var user = await _userManager.FindByIdAsync(order.UserId);
                    var orderViewModel = new OrderViewModel()
                    {
                        Id = order.Id,
                        UserId = order.UserId,
                        UserEmail = user.Email,
                        MedicineId = item.MedicineId,
                        MedicineName = item.MedicineName,
                        PictureUri = item.PictureUri,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        OrderDate = order.OrderDate,
                        Country = order.ShippingAddress.Country,
                        City = order.ShippingAddress.City,
                        District = order.ShippingAddress.District,
                        Street = order.ShippingAddress.Street,
                        ZipCode = order.ShippingAddress.ZipCode
                    };

                    orderViewModels.Add(orderViewModel);
                }
            }

            return orderViewModels;
        }

    }
}
