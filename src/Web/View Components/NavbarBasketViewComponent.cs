using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.View_Components
{
    public class NavbarBasketViewComponent : ViewComponent
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public NavbarBasketViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(basket);
        }
    }
}
