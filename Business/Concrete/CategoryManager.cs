using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService // İş kodlarının yazılacağı alan.
    {
        private ICategoryDal _categoryDal; //Constructor Injection

        public CategoryManager(ICategoryDal categoryDal) //Injection yapıldığında CategorManager olarak veri erişim katmanına bağlımlıdır.
        // Ama biraz zayıf bağımlılığı var. Çünkü interface aracılığı ile bağımlı. DataAcess katmanında kurallara uyulduğu şekilde istenilen
        //herşey yapılabilir.
        {
            _categoryDal = categoryDal;
        }


     


        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }


        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }


    }
}
