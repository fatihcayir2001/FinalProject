using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    //Şuan EfProductDal da her şey hazır.
    //baserepository de IProductDal daki kodlar olduğundan implement etmemize gerek yok
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDeatils()
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var result = from p in contex.Products
                             join c in contex.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto() 
                             { ProductId=p.ProductId,ProductName=p.ProductName,
                                 CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock
                             };
                return result.ToList();

            }



        }
    }
}
