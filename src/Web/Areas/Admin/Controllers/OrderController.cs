using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderViewModelService _orderViewModelService;

        public OrderController(IOrderViewModelService orderViewModelService)
        {
            _orderViewModelService = orderViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            var orderViewModels = await _orderViewModelService.GetAllOrderAsync();
            return View(orderViewModels);
        }

        public async Task<IActionResult> OrderDetail()
        {
            return View();
        }
    }
}
