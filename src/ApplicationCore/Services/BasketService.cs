using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepo;
        private readonly IRepository<BasketItem> _basketItemRepo;
        private readonly IRepository<Medicine> _medicineRepo;

        public BasketService(IRepository<Basket> basketRepo, IRepository<BasketItem> basketItemRepo, IRepository<Medicine> medicineRepo)
        {
            _basketRepo = basketRepo;
            _basketItemRepo = basketItemRepo;
            _medicineRepo = medicineRepo;
        }
        public async Task<Basket> AddItemToBasketAsync(string buyerId, int medicineId, int quantity)
        {
            var basket = await GetOrCreateBasketAsync(buyerId);  
            var basketItem = basket.Items.FirstOrDefault(x => x.MedicineId == medicineId);

            if (basketItem != null)
            {
                basketItem.Quantity += quantity; // eğer o ilaç sepette varsa miktarını artır.
            }
            else
            {
                var medicine = await _medicineRepo.GetByIdAsync(medicineId); // tıklanan ilacı al

                basketItem = new BasketItem()
                {
                    MedicineId = medicineId,
                    Quantity = quantity,
                    Medicine = medicine
                };

                basket.Items.Add(basketItem);  // seset içine yeni bir sepet öğesi olarak ekle.
            }

            await _basketRepo.UpdateAsync(basket); // sepeti güncelle.
            return basket;

        }

        public async Task DeleteBasketItemAsync(string buyerId, int medicineId)
        {
            var basket = await GetOrCreateBasketAsync(buyerId);
            var basketItem = basket.Items.FirstOrDefault(x => x.MedicineId == medicineId);

            if (basketItem == null) return;
            await _basketItemRepo.DeleteAsync(basketItem);
        }

        public async Task EmptyBasketAsync(string buyerId)
        {
            var basket = await GetOrCreateBasketAsync(buyerId);

            foreach (var item in basket.Items.ToList())
            {
                await _basketItemRepo.DeleteAsync(item);
            }
        }

        public async Task<Basket> GetOrCreateBasketAsync(string buyerId)
        {
            var specBasket = new BasketWithItemsSpecification(buyerId); // giriş yapan eczacının sepetini getir.
            var basket = await _basketRepo.FirstOrDefaultAsync(specBasket);

            if (basket == null) // eğer o kişinin sepeti yoksa sepet olustur.
            {
                basket = new Basket() { BuyerId = buyerId };
                await _basketRepo.AddAsync(basket);
            }

            return basket;
        }

        public async Task<Basket> SetQuantitiesAsync(string buyerId, Dictionary<int, int> quantities)
        {
            var basket = await GetOrCreateBasketAsync(buyerId);

            foreach (var item in basket.Items)
            {
                if (quantities.ContainsKey(item.MedicineId)) // Dictionary ile medicineId,quantity ikilisi tutuluyor.
                {
                    item.Quantity = quantities[item.MedicineId]; // medicineId key'inin value değerinin atamasını yapar.
                    await _basketItemRepo.UpdateAsync(item);
                }
            }

            return basket;
        }

    }
}
