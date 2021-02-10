using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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


        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }



        public Category GetById(int categoryId) //select * from Categires where CategoryId = 3 
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
