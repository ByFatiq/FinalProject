using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //DTO Data Transformation Object - Taşınacak objeler
            ProductTest();

            // CONSOLE UI -  IoC Container ile daha sonra doldurulacak.
            //CategoryTest();






        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager
                productManager = new ProductManager(new EfProductDal()); 
            // Inmemory çalışacağım demek. Bunu EfProductDal'a çekince Entity Framework'e geçer.
            // Bu sayede hangi veri tabanı ile çalışmak istiyorsak o veri tabanını ConsolUI > Program.Cs içerisinde değiştirmemiz yeterlidir.

            foreach (var product in productManager.GetProductDetails())
            { 
                Console.WriteLine(product.ProductName + "/" + product.CategoryName); 
            }
        }
    }
}
