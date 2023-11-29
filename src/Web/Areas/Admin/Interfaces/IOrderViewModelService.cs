using ApplicationCore.Entities;
using Infrastructure.Identity;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Interfaces
{
    public interface IOrderViewModelService
    {
        public Task<List<OrderViewModel>> GetAllOrderAsync();
    }
}
