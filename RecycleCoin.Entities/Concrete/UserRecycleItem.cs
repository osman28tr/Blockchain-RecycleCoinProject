using System;
using RecycleCoin.Shared.Abstract;

namespace RecycleCoin.Entities.Concrete
{
    public class UserRecycleItem : IEntity
    {

        public int Id { get; set; }
        public string UserId { get; set; }  
        public virtual AppUser User { get; set; }
        public int ProductId { get; set; }  
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public DateTime RecycleDate { get; set; }
        public int RecycleCarbon { get; set; }  

    }
}
