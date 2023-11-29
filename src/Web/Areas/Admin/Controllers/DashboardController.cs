using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IMedicineViewModelService _medicineViewModelService;

        public DashboardController(IMedicineViewModelService medicineViewModelService)
        {
            _medicineViewModelService = medicineViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            var medicines = await _medicineViewModelService.GetAllMedicinesAsync();
            return View(medicines);
        }
    }
}
