using System.Collections.Generic;
using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetListByCategory(categoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.Id == productId);
        }
        

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
