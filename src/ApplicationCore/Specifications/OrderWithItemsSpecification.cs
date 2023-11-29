using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class OrderWithItemsSpecification : Specification<Order>
    {
        public OrderWithItemsSpecification()
        {
            Query.Include(x => x.Items);
        }
    }
}
