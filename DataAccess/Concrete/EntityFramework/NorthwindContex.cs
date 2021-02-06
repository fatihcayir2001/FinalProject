using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Contex : db tabloları ile proje classlarını bağlamak
    public class NorthwindContex:DbContext
    {
        //projemizin hangi veritabanıyla ilişkili olduğunu belirttiğimiz method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //başına @ koyma nedenimiz \ dan dolayı
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True");
        }

        // public DbSet<(BizdekiClass)> (Bağlanacak class) {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
