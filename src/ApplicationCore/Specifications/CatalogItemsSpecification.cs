using Ardalis.Specification;
using System;
using System.Linq;
using MaryShoppins.ApplicationCore.Entities;

namespace MaryShoppins.ApplicationCore.Specifications
{
    public class CatalogItemsSpecification : Specification<CatalogItem>
    {
        public CatalogItemsSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
