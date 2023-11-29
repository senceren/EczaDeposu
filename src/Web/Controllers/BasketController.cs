using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            var basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(basket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketViewModel>> AddItem(int medicineId, int quantity = 1)
        {
            var basket = await _basketViewModelService.AddItemToBasketAsync(medicineId, quantity);
            return basket;
        }

        [HttpPost]
        public async Task<IActionResult> EmptyBasket()
        {
            await _basketViewModelService.EmptyBasketAsync();
            TempData["SuccessMessageTemp"] = "Sepet boş.";
            return RedirectToAction("Index", "Basket");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int medicineId)
        {
            await _basketViewModelService.RemoveItemAsync(medicineId);
            TempData["SuccessMessageTemp"] = "Başarıyla silindi.";
            return RedirectToAction("Index", "Basket");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([ModelBinder(Name = "quantities")] Dictionary<int, int> quantities)
        {
            await _basketViewModelService.UpdateQuantitiesAsync(quantities);
            TempData["SuccessMessageTemp"] = "Basket güncellendi.";
            return RedirectToAction("Index", "Basket");
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketViewModelService.GetBasketViewModelAsync();
            var vm = new CheckoutViewModel()
            {
                Basket = basket
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _basketViewModelService.CheckoutAsync(vm.Street, vm.City, vm.District, vm.Country, vm.ZipCode);
                return RedirectToAction("OrderConfirmed");
            }

            vm.Basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(vm);
        }

        [Authorize]
        public async Task<IActionResult> OrderConfirmed()
        {
            return View();
        }
    }
}
