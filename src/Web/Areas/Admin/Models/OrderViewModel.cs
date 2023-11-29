using ApplicationCore.Entities;
using Humanizer;

namespace Web.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = null!;
        public string? PictureUri { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}
