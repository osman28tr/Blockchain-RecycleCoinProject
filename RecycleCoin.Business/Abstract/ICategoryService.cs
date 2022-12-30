using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
    }
}
