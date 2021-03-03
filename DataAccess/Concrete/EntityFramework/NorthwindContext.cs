using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Contex : db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext
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
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
