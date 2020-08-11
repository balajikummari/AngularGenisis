using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductsWithTypesandBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesandBrandsSpec()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesandBrandsSpec(int Id) : base(x => x.Id == Id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
