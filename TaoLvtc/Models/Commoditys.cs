using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class Commoditys//我的商品表
    {
        [Key]
        [Required]
        public string Phone_Number { get; set; }
        [Required]
        public string ProductTitle { get; set; }
        [Required]
        public string CommodityDescription { get; set; }
        [Required]
        public string CommodityImage { get; set; }
        [Required]
        public DateTime ReleaseTime { get; set; }
        [Required]
        public Nullable<bool> GoodsState { get; set; }
    }
}