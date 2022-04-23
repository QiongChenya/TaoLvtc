using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class Administrators
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}