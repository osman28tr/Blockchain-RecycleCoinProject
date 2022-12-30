using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MySql.Data.MySqlClient;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Repositories.Concrete;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework
{
    public class EfUserRecycleItemDal : EfEntityRepositoryBase<UserRecycleItem>, IUserRecycleItemDal
    {
        private RecycleCoinDbContext _recycleCoinDbContext;

        public EfUserRecycleItemDal()
        {
            _recycleCoinDbContext = new RecycleCoinDbContext();

        }

        public List<UserRecycleItem> GetListByUser(string userId)
        {
            var userRecycleItems = new List<UserRecycleItem>(
                _recycleCoinDbContext.UserRecycleItems.SqlQuery(
                    $@"call recyclecoindb.sp_getUserRecycleItemsByUserId('{userId}');"));
            return userRecycleItems ?? null;
        }

        public List<UserRecycleItem> GetListOrderBy(string filter)
        {
            var userRecycleItems = new List<UserRecycleItem>(GetViewResult(filter));
            return userRecycleItems;
        }

        public List<UserRecycleItem> GetListOrderByDesc(string filter)
        {
            var userRecycleItems = new List<UserRecycleItem>(GetViewResult(filter));
            userRecycleItems.Reverse();
            return userRecycleItems;
        }

        public DbSqlQuery<UserRecycleItem> GetViewResult(string filter)
        {
            return _recycleCoinDbContext.UserRecycleItems.SqlQuery(
                $@"Select * from recyclecoindb.{filter}_orderbyview;");
        }

        public int GetBestRecycleAmount(int filterday)
        {
            var res = _recycleCoinDbContext.Database.SqlQuery<string>($"Select recyclecoindb.bestRecycleAmount('{filterday}');").FirstOrDefault();
            var res2 = Convert.ToInt32(res);
            return res2;
        }

        public string GetBestRecycleUserID(int filterday)
        {
            
            var res = _recycleCoinDbContext.Database.SqlQuery<string>($"Select recyclecoindb.bestRecycleUserID('{filterday}');").FirstOrDefault();


            //$@"Select recyclecoindb.bestRecycleUserID({filterday});"

            return res;
        }
    }
}
