using RecycleCoin.Entities.Concrete;

namespace RecycleCoinMvc.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        public int amount { get; set; }

        public CartItem(Product product, int amount)
        {
            this.product = product;
            this.amount = amount;
        }
    }
}