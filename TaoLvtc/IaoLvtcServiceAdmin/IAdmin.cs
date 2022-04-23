using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLvtc.Models;

namespace TaoLvtc.IaoLvtcServiceAdmin
{
    public interface IAdmin<T> where T : class
    {
        Task<bool> AdminAsync(string name,string password);
    }
}
