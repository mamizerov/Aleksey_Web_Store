using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.FIlters;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}