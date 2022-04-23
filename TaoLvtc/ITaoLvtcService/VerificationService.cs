using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaoLvtc.Models;
using System.Data.Entity;
namespace TaoLvtc.ITaoLvtcService
{
    public class VerificationService : IVerification<Verifications>
    {
        private readonly TaoLvtcDB _taoLvtcDB;
        public VerificationService()
        {
            _taoLvtcDB = new TaoLvtcDB();
        }
        public async Task<Verifications> AddVerification(Verifications verification)
        {
          var  code=  _taoLvtcDB.Verifications.Where(o => o.Phone_Number.Equals(verification.Phone_Number)).FirstOrDefault();//查询记录是否存在
            if (code != null)//如果存在修改(存在表明用户发送过多次)
            {
               code.VerificationCode = verification.VerificationCode;
               code.CreationTime = verification.CreationTime;
               code.State = verification.State;
               code.NumberOfSends = code.NumberOfSends+1;
            }
            else {//不存在则直接添加
                _taoLvtcDB.Verifications.Add(verification);
            }
            await _taoLvtcDB.SaveChangesAsync();
            return verification;
        }
        public   async Task<Verifications> SearchVerificationCode(string Phone_Number)//查询验证码
        {
            //var user = from shuju in _taoLvtcDB.Verifications where (shuju.Phone_Number.Equals(Phone_Number)) select shuju;
            //var users = _taoLvtcDB.Verifications.Where(o =>o.Phone_Number.Equals(Phone_Number)).FirstOrDefault() !=null;
            var user = await _taoLvtcDB.Verifications.FindAsync(Phone_Number);
          
            if (user == null) { //如果不存在返回Null
                return null;
            }
            var time = user.CreationTime;
            TimeSpan timeSpan = DateTime.Now.Subtract(time);//查询时间
            if (timeSpan.Days >= 1)//如果大于等于一天重置
            {
                user.NumberOfSends = 0;
                _taoLvtcDB.SaveChangesAsync().Wait();
            }
            return user;
        }
        public async Task<Verifications> UpdateVerificationStateAsync(string Phone_Number, bool state) {//修改验证码状态
            Verifications user = _taoLvtcDB.Verifications.Where(p => p.Phone_Number.Equals(Phone_Number)).FirstOrDefault();
            user.State = false; 
            await _taoLvtcDB.SaveChangesAsync();
            return user;
        }
    }
}