using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.EntityFramework;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class RecycleCoinDbContext:IdentityDbContext<AppUser>
    {
        public RecycleCoinDbContext():base("RecycleCoinDbConnection")
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserRecycleItem> UserRecycleItems { get; set; }

    }
}
