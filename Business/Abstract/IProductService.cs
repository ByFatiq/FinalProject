using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService // iş katmanında kullanacağımız servis katmanı. İş katmanının yapacağı işleri soyutlayıp metot haline getirmek için kullanıyoruz.
    {
        IDataResult<List<Product>> GetAll(); // IDataResult hem işlem sonucu hem mesajı hemde listeyi döndüren bi yapı görevi görür.
                                             //T liste tipinde product'a ait herşeyi getir.

        IDataResult<List<Product>> GetAllByCategoryId(int Id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); 

        IDataResult<List<ProductDetailDto>>GetProductDetails();
         
        IDataResult<Product> GetById (int productId);

        IResult Add (Product product);

        IResult Update(Product product);
    }
}
