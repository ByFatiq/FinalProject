using System;
using System.Collections.Generic;
using System.Text;
using Core.DateAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    { // interface metotları default public'tir.


       // Ürüne ait özel operasyonları yazmak için kullanıyoruz.
         //Ürünleri Category'ye göre listele.
         // ürün detaylarını getirmek için
         //ürün kategori tablolarına join atmak gibi

         List<ProductDetailDto> GetProductDetails();


    }
}


//Code Refactoring - Kod İyileştirmesi yapıldı.
