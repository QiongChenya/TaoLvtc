using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TaoLvtc.IaoLvtcServiceAdmin;
using TaoLvtc.Models;

namespace TaoLvtc.Controllers
{
    
    public class AdminController : ApiController
    {
        private  readonly IAdmin<Administrators> _admin;
        public AdminController(IAdmin<Administrators> admin)
        {
                _admin = admin;
        }
        // GET: api/Admin
        
        public IEnumerable<string> Get(string user)
        {
            return new string[] { user};
        }

        // GET: api/Admin/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [HttpPost]
        // POST: api/Admin
        
        public async Task<IHttpActionResult>  Post([FromBody]Administrators formdata)
        {

            bool cunzai = await _admin.AdminAsync(formdata.UserName,formdata.Password);
            if (cunzai != true)
            {
                return Json(new { Message = "账号或密码错误" });
            }
            return Ok(cunzai);
                
        }
        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
