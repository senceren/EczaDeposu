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
        public string PictureUri { get; set; } = null!;

        public string Description = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
