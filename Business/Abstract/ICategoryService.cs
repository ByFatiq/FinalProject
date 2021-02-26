using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService // Kategori ile ilgili neyi dış dünyaya servis etmek istiyorsak o operasyonları yazıyoruz.
    {

  
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);

    }
}
