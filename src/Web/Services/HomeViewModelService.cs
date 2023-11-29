using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Medicine> _medicineRepo;

        public HomeViewModelService(IRepository<Medicine> medicineRepo)
        {
            _medicineRepo = medicineRepo;
        }
        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var medicines = await _medicineRepo.GetAllAsync();
            var homeViewModel = new HomeViewModel
            {
                Medicines = medicines.Select(x => new MedicineViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    PictureUri = x.PictureUri
                }).ToList()
            };

            return homeViewModel;
        }
    }
}
