using System.Collections.Generic;
using System.Linq;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Repositories.Concrete;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product>,IProductDal
    {
        private RecycleCoinDbContext recycleCoinDbContext;
        public List<Product> GetListByCategory(int categoryId)
        {
            recycleCoinDbContext = new RecycleCoinDbContext();
             var products = new List<Product>(recycleCoinDbContext.Products.SqlQuery($@"call recyclecoindb.sp_getProductsByCategoryId({categoryId});"));
            return products ?? null;
        }
    }
}
