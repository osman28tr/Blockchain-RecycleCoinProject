using RecycleCoin.Entities.Concrete;
using System.Collections.Generic;

namespace RecycleCoin.DataAccess.Abstract
{
    public interface IUserRecycleItemDal : IEntityRepositoryBase<UserRecycleItem>
    {
        List<UserRecycleItem> GetListByUser(string userId);
        List<UserRecycleItem> GetListOrderBy(string filter);
        List<UserRecycleItem> GetListOrderByDesc(string filter);
        int GetBestRecycleAmount(int filterday);
        string GetBestRecycleUserID(int filterday);
    }
}
