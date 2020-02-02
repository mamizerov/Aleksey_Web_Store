using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.FIlters
{
    /// <summary>
    /// Класс для фильтрации товаров на сайте
    /// </summary>
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }

}
