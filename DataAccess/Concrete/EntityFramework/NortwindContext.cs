using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{//Context : DB Tabloları ile proje Classlarını bağlamak.


    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Proje hangi veri tabanı ile ilişkiliyse onu belirtiyoruz.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; } //Hangi tablo hangi clasa denk geliyor.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
