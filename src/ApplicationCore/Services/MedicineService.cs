using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IRepository<Medicine> _medicineRepo;

        public MedicineService(IRepository<Medicine> medicineRepo)
        {
            _medicineRepo = medicineRepo;
        }
        public async Task<Medicine> AddMedicineAsycn(Medicine medicine)
        {
            var newMedicine = await _medicineRepo.AddAsync(medicine);
            return newMedicine;
        }

        public async Task DeleteMedicineAsync(int medicineId)
        {
            var medicine = await _medicineRepo.GetByIdAsync(medicineId);
            await _medicineRepo.DeleteAsync(medicine);
        }

        public async Task EditMedicineAsync(Medicine medicine)
        {
            await _medicineRepo.UpdateAsync(medicine);
        }

        public async Task<List<Medicine>> GetAllMedicinesAsync()
        {
            var medicines = await _medicineRepo.GetAllAsync();
            return medicines;
        }

        public async Task<Medicine> GetMedicineByIdAsync(int medicineId)
        {
            var medicine = await _medicineRepo.GetByIdAsync(medicineId);
            return medicine;
        }
    }
}
