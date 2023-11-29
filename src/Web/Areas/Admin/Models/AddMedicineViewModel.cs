using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models
{
    public class AddMedicineViewModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public IFormFile Picture { get; set; } = null!;

        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Stock { get; set; }
    }
}
