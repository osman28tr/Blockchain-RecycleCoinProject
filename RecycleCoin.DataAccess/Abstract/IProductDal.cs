using System.Collections.Generic;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepositoryBase<Product>
    {
        List<Product> GetListByCategory(int categoryId);
    }
}
