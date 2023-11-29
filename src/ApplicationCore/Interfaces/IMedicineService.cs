using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IMedicineService
    {
        public Task<List<Medicine>> GetAllMedicinesAsync();
        public Task<Medicine> GetMedicineByIdAsync(int medicineId);
        public Task<Medicine> AddMedicineAsycn(Medicine medicine);
        public Task DeleteMedicineAsync(int medicineId);
        public Task EditMedicineAsync(Medicine medicine);
    }
}
