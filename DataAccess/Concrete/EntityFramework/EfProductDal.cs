using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet başkalarının kodlarına ulaşabileceğimiz yer
    //data accese sağ tıklayıp manage NuGet projectsden ulaşabiliriz 

    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //bu performansı artıracak bi kod using bitince hafızadan kodu siler
            using (NorthwindContex contex = new NorthwindContex())
            {
                
                var addedEntity = contex.Entry(entity); //git veri kaynağından gönderdiğimiz nesneyi eşleştir referansı yakalamak için
                addedEntity.State = EntityState.Added;  //durumunu belirttik silindi mi eklendi mi güncellendi mi
                contex.SaveChanges();                   
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                return contex.Set<Product>().SingleOrDefault(filter);       //Set<Product> producta yerleş demek

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                return filter == null ? contex.Set<Product>().ToList() :    //kısacası select * from products döndürür
                    contex.Set<Product>().Where(filter).ToList();  

            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {

                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
