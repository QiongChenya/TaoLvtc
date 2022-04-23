using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TaoLvtc.ITaoLvtcService;
using TaoLvtc.Models;

namespace TaoLvtc.Controllers
{
    public class UserController : ApiController
    {
        //static readonly IUserService<Users> userService = new UserService();
        static readonly IVerification<Verifications> _verification = new VerificationService();
        private  readonly IUserService<Users> _userService;
        public UserController(IUserService<Users> userService)
        {
            _userService = userService;;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            var model = _userService.GetUserAll();
            return model;
        }

        // GET: api/User/5
        [HttpGet]
        public  bool Get(string id)//查询用户是否存在
        {
            var userName =  _userService.GetSearch(id);
            if (userName == true)
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        public async Task<IHttpActionResult> PostAdd(string Phone_Number, int VerificationCodes) {

            var userCode =await _verification.SearchVerificationCode(Phone_Number);//获取发送的验证码
            if (userCode==null) {
                return Json(new { Message="该手机号未发送验证码"});
            }
            var shijian=  System.DateTime.Now- userCode.CreationTime;
            if (shijian.Minutes > 1)//判断验证码时间并修改状态
            {
                await _verification.UpdateVerificationStateAsync(Phone_Number,false);
                return Json(new { Message= "该验证码已过期"}); ;
            }
            if (VerificationCodes.Equals(userCode.VerificationCode))//判断验证码
            {
            string path = HttpContext.Current.Server.MapPath("~/Images/DefaultAvatar/");//默认的图片路径
            string fileName = "头像1.jpg";//默认的头像
            string Picture = path + fileName;

                Users user = new Users()
                {
                    Phone_Number = Phone_Number,
                    UserName= Phone_Number,
                    Image = Picture,
                    CreationTime = System.DateTime.Now,
                    Account_Status = true,
            };
            try
            {
                await _userService.PostUserAdd(user);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            }
            else
            {
                return Json(new { Message = "您输入的验证码不正确" });
            }

            return Ok(new { Message="注册成功"});
        }
        public async Task<string> SendCode(string Phone_Number) {//封装发送验证码
            int verificationCode;//定义随机数
            var user =  Get(Phone_Number);//查询用户是否存在
            if (user == false)
            {
                string Uid = "xianmu";
                string Key = "d41d8cd98f00b204e980";
                Random random = new Random();
                verificationCode = random.Next(100000, 999999);
                Verifications verification = new Verifications()
                {
                    Phone_Number = Phone_Number,
                    VerificationCode = verificationCode,
                    CreationTime = System.DateTime.Now,
                    State = true,
                    NumberOfSends = 1,
                };
                //添加验证码
                string smsText = "验证码为:" + verificationCode;
                string url = "http://utf8.api.smschinese.cn/?Uid=" + Uid + "&Key=" + Key + "&smsMob=" + Phone_Number + "&smsText=" + smsText;
               //string code= GetHtmlFromUrl(url);//发送
               // if (Convert.ToInt32(code) >= 1)
               // {
                    await _verification.AddVerification(verification);//添加验证码到数据库
               // }
                //else {
                //    return "出问题了";
                //}
                
            }
            else
            {
                return  "该号码已被注册" ;
            }
            return "发送成功";
        }
        // POST: api/User
        [HttpGet]
        public async Task<IHttpActionResult> GetAdd(string Phone_Number)//发送验证码
        {
            string message = "";
            var code =await _verification.SearchVerificationCode(Phone_Number);//查询
             
            if (code == null)
            {
                message = await SendCode(Phone_Number);
            }
            else if (code.NumberOfSends >= 5)
            {
                return Json(new { Message = "您发送验证码次数过多，请24小时后重试" });
            }
            else {
                message = await SendCode(Phone_Number);
            }
            return Ok(new { message});
        }

        // string userName = HttpContext.Current.Request.Form["Phone_Number"];//获取前端传过来的电话号码
        //var file = HttpContext.Current.Request.Files["Picture"];
        //file.SaveAs(path+ file.FileName);
        //await Post(Phone_Number, verificationCodes);
        public string GetHtmlFromUrl(string url)//验证码发送
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "Get";
                hr.Timeout = 30 * 60 * 1000;
                
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
                }
            catch
            {
                strRet = null;
            }
            return strRet;
        }
        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
