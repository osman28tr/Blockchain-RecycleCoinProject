using RecycleCoin.Shared.Abstract;

namespace RecycleCoin.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Carbon { get; set; }
        public virtual Category Category { get; set; }

    }
}
