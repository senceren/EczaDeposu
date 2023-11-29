using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? PictureUri { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
    }
}
