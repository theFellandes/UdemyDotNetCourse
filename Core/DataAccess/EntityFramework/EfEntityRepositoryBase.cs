using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity: class, IEntity, new()
    //new'lenebilir olmalı çünkü DbContext'i de geçirebilir, new'lenebilir dersek DbContext geçirmez
    where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            //verdiğimiz filtreye göre tek bir eleman dönmesini sağlıyoruz.
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            //verdiğimiz filtre gönderilmediyse listenin tamamını döndürmek istiyoruz.
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            //Unit of work pattern'ı implement eder
            using (var context = new TContext())
            {
                //gelen entity'yi context'e abone ediyoruz, attach ediyoruz
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                //gelen entity'yi context'e abone ediyoruz, attach ediyoruz
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}