using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
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
        public async Task<HomeViewModel> GetHomeViewModelAsync(int pageId)
        {
            var medicines = await _medicineRepo.GetAllAsync();
            var specMedicinePaginated = new PaginationSpecification((pageId - 1) * Constants.ITEMS_PER_PAGE, Constants.ITEMS_PER_PAGE);
            var medicinesPaginated = await _medicineRepo.GetAllAsync(specMedicinePaginated);
            var totalItems = medicines.Count();

            var homeViewModel = new HomeViewModel
            {
                Medicines = medicinesPaginated.Select(x => new MedicineViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    PictureUri = x.PictureUri
                }).ToList(),

                Pagination = new PaginationViewModel()
                {
                    PageId = pageId,
                    ItemsOnPage = medicinesPaginated.Count(),
                    TotalItems = totalItems
                }
            };

            return homeViewModel;
        }
    }
}
