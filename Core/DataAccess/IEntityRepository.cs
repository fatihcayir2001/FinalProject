using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Entities referans vermedik çünkü verirsek bağımlı olur
    //T yi sınırlamaya generic constraint denir
    //T sadece class olabilir
    //class: reference tip olabilir demek
    //new() newlenebilir olmalı 
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        //Get allın içine yazdığımız kod sayesinde => yani lambdayı kullanabiliriz
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //hepsini değilde verilen değerdeki datayı çekmek için(kategoriye,ürün id ye görevsvs) verdiğimiz şey filter demek
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
