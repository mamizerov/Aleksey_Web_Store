using System.Collections.Generic;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.FIlters;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}