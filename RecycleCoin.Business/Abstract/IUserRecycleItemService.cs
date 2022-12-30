using RecycleCoin.Entities.Concrete;
using System.Collections.Generic;

namespace RecycleCoin.Business.Abstract
{
    public interface IUserRecycleItemService
    {
        List<UserRecycleItem> GetList();
        List<UserRecycleItem> GetListByUserId(string userId);
        List<UserRecycleItem> GetListOrderBy(string filter);
        List<UserRecycleItem> GetListOrderByDesc(string filter);

        int GetBestRecycleAmount(int filterday);
        string GetBestRecycleUserID(int filterday);
        void Add(UserRecycleItem userRecycleItem);
    }
}
