using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // Inmemory çalışacağım demek. Bunu EfProductDal'a çekince Entity Framework'e geçer.
            // Bu sayede hangi veri tabanı ile çalışmak istiyorsak o veri tabanını ConsolUI > Program.Cs içerisinde değiştirmemiz yeterlidir.

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }


            
        }
    }
}
