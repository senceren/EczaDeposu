using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class OrderItem : BaseEntity
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = null!;
        public string? PictureUri { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}
