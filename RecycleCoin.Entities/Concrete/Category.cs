using System.Collections.Generic;
using RecycleCoin.Shared.Abstract;

namespace RecycleCoin.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
