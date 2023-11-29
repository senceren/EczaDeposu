using ApplicationCore.Entities;
using Web.Models;

namespace Web.Extensions
{
    public static class MappingExtensions
    {
        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            return new BasketViewModel()
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                BasketItems = basket.Items.Select(x => new BasketItemViewModel()
                {
                    Id = x.Id,
                    MedicineId = x.MedicineId,
                    MedicineName = x.Medicine.Name,
                    PictureUri = x.Medicine.PictureUri ?? "noimage.jpg",
                    Quantity = x.Quantity,
                    UnitPrice = x.Medicine.Price
                }).ToList()
            };
        }
    }
}
