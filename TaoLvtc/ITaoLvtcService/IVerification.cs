using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLvtc.Models;

namespace TaoLvtc.ITaoLvtcService
{
    public interface IVerification<T>where T: class
    {
        Task<Verifications> AddVerification(Verifications verification);//添加验证码
        Task<Verifications> SearchVerificationCode(string Phone_Number);//查询验证码记录
        Task<Verifications> UpdateVerificationStateAsync(string Phone_Number, bool state);//修改验证码状态
    }
}
