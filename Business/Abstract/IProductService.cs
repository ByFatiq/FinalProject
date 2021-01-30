using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService // iş katmanında kullanacağımız servis katmanı.
    {
        List<Product> GetAll();
    }
}
