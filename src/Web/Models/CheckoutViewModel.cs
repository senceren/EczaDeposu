using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web.Models
{
    public class CheckoutViewModel
    {
        public BasketViewModel? Basket { get; set; } = null!;

        [Required, MaxLength(180)]
        [DisplayName("Mahalle")]
        public string Street { get; set; } = null!;

        [Required, MaxLength(180)]
        [DisplayName("İl")]
        public string City { get; set; } = null!;

        [MaxLength(60)]
        [DisplayName("İlçe")]
        public string? District { get; set; }

        [Required, MaxLength(180)]
        [DisplayName("Ülke")]
        public string Country { get; set; } = null!;

        [Required, MaxLength(180)]
        [DisplayName("Zip")]
        public string ZipCode { get; set; } = null!;

        [Required]
        [DisplayName("Kart Üzerindeki İsim")]
        public string CCHolder { get; set; } = null!;

        [Required, MaxLength(16)]
        [DisplayName("Kart Numarası")]
        public string CCNumber { get; set; } = null!;

        [Required]
        [DisplayName("Geçerlilik Tarihi")]
        [RegularExpression(@"^[0-9]{2}\/[0-9]{2}$", ErrorMessage = "Invalid {0}.")]
        public string CCExpiration { get; set; } = null!;

        [Required]
        [DisplayName("CVV")]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Invalid {0}.")]
        public string CCCvv { get; set; } = null!;
    }
}
