using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class BasketItem : BaseEntity
    {
        public int BasketId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}
