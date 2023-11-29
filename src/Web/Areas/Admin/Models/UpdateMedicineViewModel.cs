using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models
{
    public class UpdateMedicineViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; } = null!;
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string Description = null!;
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Stock { get; set; }
    }
}
