using RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts;
using RecycleCoin.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RecycleCoin.DataAccess.Abstract;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework.Repositories.Concrete
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        private RecycleCoinDbContext recycleCoinDbContext = new RecycleCoinDbContext();

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return recycleCoinDbContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public void Add(TEntity entity)
        {
            var addedEntity = recycleCoinDbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            recycleCoinDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = recycleCoinDbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            recycleCoinDbContext.SaveChanges();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null
                ? recycleCoinDbContext.Set<TEntity>().Where(filter).ToList()
                : recycleCoinDbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = recycleCoinDbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            recycleCoinDbContext.SaveChanges();
        }
    }
}
