using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService // Kategori ile ilgili neyi dış dünyaya servis etmek istiyorsak o operasyonları yazıyoruz.
    {
        List<Category> GetAll();
        Category GetById(int categoryId);


    }
}
