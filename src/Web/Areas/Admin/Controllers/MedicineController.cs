using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MedicineController : Controller
    {
        private readonly IMedicineViewModelService _medicineViewModelService;

        public MedicineController(IMedicineViewModelService medicineViewModelService)
        {
            _medicineViewModelService = medicineViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            var medicines = await _medicineViewModelService.GetAllMedicinesAsync();
            return View(medicines);
        }

        public IActionResult AddMedicine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicine(AddMedicineViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _medicineViewModelService.AddMedicineAsycn(vm);
                TempData["Success"] = "Başarıyla eklendi.";
                return RedirectToAction("Index", "Medicine");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMedicine(int medicineId)
        {
            await _medicineViewModelService.DeleteMedicineAsync(medicineId);
            TempData["Success"] = "Başarıyla silindi.";
            return RedirectToAction("Index", "Medicine");
        }
        public async Task<IActionResult> EditMedicine(int medicineId)
        {
            var medicine = await _medicineViewModelService.GetMedicineByIdAsync(medicineId);
            var vm = new UpdateMedicineViewModel()
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Description = medicine.Description,
                Price = medicine.Price,
                Stock = medicine.Stock
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditMedicine(UpdateMedicineViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _medicineViewModelService.EditMedicineAsync(vm);
                TempData["Success"] = "Başarıyla güncellendi.";
                return RedirectToAction("Index", "Medicine");
            }

            return View();
        }
    }
}
