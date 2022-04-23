using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class TaoLvtcDB : DbContext
    {
        public TaoLvtcDB() : base("name=TaoLvtc")
        {
        }
        public DbSet<Users> Users { get; set; }//用户表
        public DbSet<Verifications> Verifications { get; set; }//验证码表
        public DbSet<BrowsingHistorys> BrowsingHistorys { get; set; }//浏览记录表
        public DbSet<BuyingForms> BuyingForms { get; set; }//求购表
        public DbSet<CollectionLists> CollectionLists { get; set; }//商品收藏
        public DbSet<Commoditys> Commoditys { get; set; }//商品表
        public DbSet<Recyclings> Recyclings { get; set; }//回收表
        public DbSet<UserLoginInformations> UserLoginInformations { get; set; }//用户登录信息
        public DbSet<SoldTables> SoldTables { get; set; }//用户卖出表
        public DbSet<Administrators> Administrators { get; set; }//管理员表

    }
}