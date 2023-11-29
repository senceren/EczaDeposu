namespace Web.Models
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUri { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
