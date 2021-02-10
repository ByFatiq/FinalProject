using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DateAccess
{

    //generic constraint -- Generic Kısıtlama.
    //class : Referans Tip
    //T>> IEntity de olabilir veya IEntity implemente eden bir nesne olabilir.IEntity ise newlenemez.
    // new(); yalnızca newlenebilir olmalı
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null); //filtre yazabilmemizi sağlıyor. 
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entitiy);
        void Update(T entitiy);
        void Delete(T entitiy);

        
    }
}
