using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaoLvtc.Models;

namespace TaoLvtc.ITaoLvtcService
{
    public class UserService : IUserService<Users>
    {
        private readonly TaoLvtcDB _taoLvtcDB;
        public UserService(TaoLvtcDB taoLvtcDB) {
            _taoLvtcDB = taoLvtcDB;
        }
        public  bool GetSearch(string id)
        {
           var model=  _taoLvtcDB.Users.Any(o=>o.Phone_Number.Equals(id));
            return model;
        }

        public Task<Users> GetUserRemove(Users user)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> PostUserAdd(Users user)
        {
             _taoLvtcDB.Users.Add(user);
            await _taoLvtcDB.SaveChangesAsync();
            return user;
        }

        public IEnumerable<Users> GetUserAll()
        {
           var model=_taoLvtcDB.Users.ToList();
            return model;
        }
    }
}