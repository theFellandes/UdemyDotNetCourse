using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    //Generic Repository, T reference tipi olmalı, nesne IEntity
    //türünde olmalı ve IEntity'yi yollamamak için new'lenebilir nesne
    //olmalı şartını koyuyoruz.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Product türünde tek bir nesne, id'sine göre eleman almak için
        //Func delegasyonu
        T Get(Expression<Func<T, bool>> filter);
        //Gönderilen filtre'ye göre List döndürecek Nullable list
        IList<T> GetList(Expression<Func<T, bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}