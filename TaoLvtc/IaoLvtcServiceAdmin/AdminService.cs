using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaoLvtc.Models;

namespace TaoLvtc.IaoLvtcServiceAdmin
{
    public class AdminService : IAdmin<Administrators>
    {
        private readonly TaoLvtcDB _taoLvtcDB;
        public AdminService(TaoLvtcDB taoLvtcDB)
        {
                _taoLvtcDB = taoLvtcDB;
        }
        public async Task<bool> AdminAsync(string username, string password)
        {
          var model =await _taoLvtcDB.Administrators.AnyAsync(o=>o.UserName.Equals(username)&&o.Password.Equals(password));
            return model;
        }
    }
}