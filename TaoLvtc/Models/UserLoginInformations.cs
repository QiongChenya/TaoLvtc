using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class UserLoginInformations//用户登录信息表
    {
        [Key]
        public string Phone_Number { get; set; }
        public string IPAddress { get; set; }//Ip地址
        public string UnreadMessages { get; set; }//未读
    }
}