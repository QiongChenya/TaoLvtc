using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaoLvtc.Models;

namespace TaoLvtc.ITaoLvtcService
{
    public interface IUserService<T> where T : class
    {
        IEnumerable<Users> GetUserAll();
        Task<Users> PostUserAdd(Users user);
        Task<Users> GetUserRemove(Users user);
        bool GetSearch(string id);
    }
}