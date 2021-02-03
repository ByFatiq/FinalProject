using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

// İş Katmanı Somut Sınıfı
namespace Business.Concrete
{
    public class ProductManager : IProductService /*ProductManager Newlendiğinde constructor(18. Satırda) bloguna 
tanımlanan Tanımlanan referanı veriyoruz.*/
    
    {// İş kodları varsa;

        IProductDal _productDal;//Dependency Injection - Burada bunu yapmamızın sebebi DateAcess Layer katmanı ile haberleştirmek. 

        public ProductManager(IProductDal productDal) // Soyut nesne ile bağlantı kuruyoruz.
        {
            _productDal = productDal; 
        }
        

        public List<Product> GetAll()
        {
            //İş Kodları
            //Yetkisi var mı gibi kodlar yazılır.
            //if kodları burada yer alır.
            return _productDal.GetAll(); //Eğer iş kodlarından geçiyorsa Veri tabanına gidiyor ve
                                         //iş kodlarından geçtiği için datayı date access veri aktarıyor.

        }

        public List<Product> GetAllByCategoryId(int Id) // CategoryId 'ye göre getir.
        {
            return _productDal.GetAll(p => p.CategoryId == Id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max) // Fiyat aralığı min - max değerleri getirir.
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
