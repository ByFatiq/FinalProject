using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCategoryDal :ICategoryDal
    {
        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Category>().ToList() : context.Set<Category>().Where(filter).ToList();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Category entitiy)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
