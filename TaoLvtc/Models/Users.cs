using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public  class Users
    {
        [Key]
        [Required(ErrorMessage ="请输入手机号")]
        [StringLength(11)]
        public string Phone_Number { get; set; }//电话号码
        [Required]
        public string UserName { get; set; }//用户名
        public string Sex { get; set; }//性别
        public string PassWord { get; set; }//密码
        [Required]
        public string Image { get; set; }//头像
        public string Follow { get; set; }//关注对象
        public int Fans { get; set; }//粉丝数
        [Required]
        public DateTime CreationTime { get; set; }//用户创建时间
        [Required]
        public Nullable<bool> Account_Status { get; set; }//账号状态
    }
}