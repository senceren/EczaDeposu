﻿namespace Web.Models
{
    public class HomeViewModel
    {
        public List<MedicineViewModel> Medicines { get; set; } = new();

        public PaginationViewModel Pagination { get; set; } = null!;
    }
}
