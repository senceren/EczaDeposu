using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.Security.Claims;
using Web.Extensions;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        string BuyerId => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public BasketViewModelService(IBasketService basketService, IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity)
        {
            var basket = await _basketService.AddItemToBasketAsync(BuyerId, productId, quantity);
            return basket.ToBasketViewModel();
        }

        public async Task EmptyBasketAsync()
        {
            await _basketService.EmptyBasketAsync(BuyerId);
        }

        public async Task<BasketViewModel> GetBasketViewModelAsync()
        {
            var basket = await _basketService.GetOrCreateBasketAsync(BuyerId);
            return basket.ToBasketViewModel();
        }

        public async Task RemoveItemAsync(int productId)
        {
            await _basketService.DeleteBasketItemAsync(BuyerId, productId);
        }

        public async Task<BasketViewModel> UpdateQuantitiesAsync(Dictionary<int, int> quantities)
        {
            var basket = await _basketService.SetQuantitiesAsync(BuyerId, quantities);
            return basket.ToBasketViewModel();
        }

        public async Task CheckoutAsync(string street, string city, string? state, string country, string zip)
        {
            Address shippingAddress = new Address()
            {
                Street = street,
                City = city,
                State = state,
                Country = country,
                ZipCode = zip
            };

            await _orderService.CreateOrderAsync(BuyerId, shippingAddress);
            await _basketService.EmptyBasketAsync(BuyerId);
        }
    }
}
