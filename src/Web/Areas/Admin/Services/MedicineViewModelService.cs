using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;
using Web.Models;

namespace Web.Areas.Admin.Services
{
    public class MedicineViewModelService : IMedicineViewModelService
    {
        private readonly IMedicineService _medicineService;

        public MedicineViewModelService(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        public async Task AddMedicineAsycn(AddMedicineViewModel medicine)
        {
            var newMedicine = new Medicine()
            {
                Name = medicine.Name,
                Description = medicine.Description,
                Price = medicine.Price,
                Stock = medicine.Stock
            };

            string ext = Path.GetExtension(medicine.Picture.FileName);
            string fileName = Path.Combine(Guid.NewGuid().ToString() + ext);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/medicines", fileName);

            using (var fileStream = File.Create(imagePath))
            {
                medicine.Picture.CopyTo(fileStream);
            }

            newMedicine.PictureUri = fileName;
            await _medicineService.AddMedicineAsycn(newMedicine);
        }

        public async Task DeleteMedicineAsync(int medicineId)
        {
            await _medicineService.DeleteMedicineAsync(medicineId);
        }

        public async Task EditMedicineAsync(UpdateMedicineViewModel medicine)
        {
            var updatedMedicine = await _medicineService.GetMedicineByIdAsync(medicine.Id);

            updatedMedicine.Id = medicine.Id;
            updatedMedicine.Name = medicine.Name;
            updatedMedicine.Description = medicine.Description;
            updatedMedicine.Price = medicine.Price;
            updatedMedicine.Stock = medicine.Stock;

            if (medicine.Picture != null)
            {
                string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/medicines", updatedMedicine.PictureUri);

                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }

                string ext = Path.GetExtension(medicine.Picture.FileName);
                string fileName = Path.Combine(Guid.NewGuid().ToString() + ext);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/medicines", fileName);

                using (var fileStream = File.Create(imagePath))
                {
                    medicine.Picture.CopyTo(fileStream);
                }
                updatedMedicine.PictureUri = fileName;
            }

            await _medicineService.EditMedicineAsync(updatedMedicine);

        }

        public async Task<List<Medicine>> GetAllMedicinesAsync()
        {
            var medicines = await _medicineService.GetAllMedicinesAsync();
            return medicines;
        }

        public async Task<Medicine> GetMedicineByIdAsync(int medicineId)
        {
            var medicine = await _medicineService.GetMedicineByIdAsync(medicineId);
            return medicine;
        }
    }
}
