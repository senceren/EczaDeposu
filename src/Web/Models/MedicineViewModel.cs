namespace Web.Models
{
    public class MedicineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PictureUri { get; set; } 

        public string Description = null!;
        public decimal Price { get; set; }
    }
}
