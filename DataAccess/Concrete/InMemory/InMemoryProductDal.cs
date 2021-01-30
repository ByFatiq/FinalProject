using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;

        public InMemoryProductDal()//constructor Uygulama newlendiği anda çalışır.
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitInStock =15, UnitPrice = 15}, 
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnitInStock =500, UnitPrice = 3},
                new Product{ProductId = 3,CategoryId = 1,ProductName = "Telefon",UnitInStock =1500, UnitPrice = 2}, 
                new Product{ProductId = 4,CategoryId = 1,ProductName = "Klavye",UnitInStock =150, UnitPrice = 65}, 
                new Product{ProductId = 5,CategoryId = 1,ProductName = "Fare",UnitInStock =85, UnitPrice = 1}

            };
        }

     

       

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {//LINQ dile Entegre sorgulama.
            //Product producttoDelete= null; 49.Satır Kısaltması olduğu için commendledik.


            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        producttoDelete = p;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); // bu kod foreach'i yapıyor.
            //p=> Her p için git bak benim gönderdiğim product id'si eşit mi? Eşit olanı sil, diyoruz
            _products.Remove(product);


        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); // Yeni bir liste haline getirip onu döndürür.
        }

        public void Update(Product product)
        {//Gönderdiğim ürün ID'sine sahip olan listedeki ürünü bul - 60 * 63 Değerleri eşitle.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); // bu kod foreach'i yapıyor.

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }



        public List<Product> GetAll()
        {
            return _products;
        }

    }
}
