using System.Collections.Generic;
using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.Business.Concrete
{
    public class UserRecycleItemManager : IUserRecycleItemService
    {
        private readonly IUserRecycleItemDal _userRecycleItemDal;

        public UserRecycleItemManager(IUserRecycleItemDal _userRecycleItemDal)
        {
            this._userRecycleItemDal = _userRecycleItemDal;
        }

        public List<UserRecycleItem> GetList()
        {
            return _userRecycleItemDal.GetList();
        }

        public List<UserRecycleItem> GetListByUserId(string userId)
        {
            return _userRecycleItemDal.GetListByUser(userId);
        }
        
        public List<UserRecycleItem> GetListOrderBy(string filter)
        {
            return _userRecycleItemDal.GetListOrderBy(filter);
        }

        public List<UserRecycleItem> GetListOrderByDesc(string filter)
        {
            return _userRecycleItemDal.GetListOrderByDesc(filter);
        }

        public void Add(UserRecycleItem userRecycleItem)
        {
            _userRecycleItemDal.Add(userRecycleItem);
        }

        public int GetBestRecycleAmount(int filterday)
        {
            return _userRecycleItemDal.GetBestRecycleAmount(filterday);
        }
        public string GetBestRecycleUserID(int filterday)
        {
            return _userRecycleItemDal.GetBestRecycleUserID(filterday);
        }

    }
}
