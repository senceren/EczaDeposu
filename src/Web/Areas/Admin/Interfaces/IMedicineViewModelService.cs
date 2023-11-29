using ApplicationCore.Entities;
using Web.Areas.Admin.Models;
using Web.Models;

namespace Web.Areas.Admin.Interfaces
{
    public interface IMedicineViewModelService
    {
        public Task<List<Medicine>> GetAllMedicinesAsync();
        public Task<Medicine> GetMedicineByIdAsync(int medicineId);
        public Task AddMedicineAsycn(AddMedicineViewModel medicine);
        public Task DeleteMedicineAsync(int medicineId);
        public Task EditMedicineAsync(UpdateMedicineViewModel medicine);
    }
}
