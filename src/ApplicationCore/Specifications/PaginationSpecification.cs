using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class PaginationSpecification : Specification<Medicine>
    {
        public PaginationSpecification(int skip, int take)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
