﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class  InMemoryProductDal : IProductDal
    {
        private List<Product> _products; //Ürünlerin Bellekte Referansını Oluşturur.
        //private IProductDal _productDalImplementation;

        public InMemoryProductDal()//constructor Uygulama newlendiği anda çalışır.
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitsInStock =15, UnitPrice = 15}, 
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnitsInStock =500, UnitPrice = 3},
                new Product{ProductId = 3,CategoryId = 1,ProductName = "Telefon",UnitsInStock =1500, UnitPrice = 2}, 
                new Product{ProductId = 4,CategoryId = 1,ProductName = "Klavye",UnitsInStock =150, UnitPrice = 65}, 
                new Product{ProductId = 5,CategoryId = 1,ProductName = "Fare",UnitsInStock =85, UnitPrice = 1}

            };
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {//LINQ dile Entegre sorgulama demektir.
            //Product producttoDelete= null; 49.Satır LINQ şeklinde kısaltarak yazdığımız için commendledik.


            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        producttoDelete = p;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); // bu kod foreach'i yapıyor.
            //p=> Her p için git bak benim gönderdiğim product id'si eşit mi? Eşit olanı sil, diyoruz
            //*.SingleOrDefault genelde ID aramalarında kullanılır.
            //*.FirstOrDefault & *.First >> ALTERNATİFLERİ

            _products.Remove(productToDelete);


        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAll()
        {
            return _products;
        }
        

        public void Update(Product product)
        {//Gönderdiğim ürün ID'sine sahip olan listedeki ürünü bul - 68 * 71. satıra kadar olan Değerleri eşitle.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); // bu kod foreach'i yapıyor.

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }



        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // Yeni bir liste haline getirip onu döndürür.

            /*Where içerideki koşula uyan tüm elemanları yeni liste haline getirir.
             return ile bu liste döndürülür.*/
        }

    }
}
