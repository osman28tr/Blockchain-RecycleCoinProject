using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Repositories.Concrete;
using RecycleCoin.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category>,ICategoryDal
    {

        private RecycleCoinDbContext recycleCoinDbContext;

    }
}
