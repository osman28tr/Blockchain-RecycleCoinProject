using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RecycleCoin.Shared.Abstract;

namespace RecycleCoin.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

}
