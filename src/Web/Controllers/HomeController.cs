﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Pharmacist")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewModelService _homeViewModelService;

        public HomeController(ILogger<HomeController> logger, IHomeViewModelService homeViewModelService)
        {
            _logger = logger;
            _homeViewModelService = homeViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var medicines = await _homeViewModelService.GetHomeViewModelAsync();
            return View(medicines);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}