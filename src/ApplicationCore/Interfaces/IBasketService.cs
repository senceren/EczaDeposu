using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetOrCreateBasketAsync(string buyerId);

        Task<Basket> AddItemToBasketAsync(string buyerId, int medicineId, int quantity);

        Task<Basket> SetQuantitiesAsync(string buyerId, Dictionary<int, int> quantities);

        Task DeleteBasketItemAsync(string buyerId, int medicineId);

        Task EmptyBasketAsync(string buyerId);
    }
}
