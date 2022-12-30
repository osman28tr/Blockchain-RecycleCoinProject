using RecycleCoin.Entities.Concrete;
using System.Collections.Generic;

namespace RecycleCoin.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<Product> GetListByCategory(int categoryId);
        Product GetById(int productId);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
