using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class Recyclings//用户删除商品时收集信息
    {
        [Key]
        [Required]
        public string Phone_Number { get; set; }
        [Required]
        public string CommodityTitle { get; set; }//商品标题
        [Required]
        public string CommodityDescription { get; set; }//商品描述
        [Required]
        public string CommodityImage { get; set; }//图片路径
        [Required]
        public DateTime ReleaseTime { get; set; }
        [Required]
        public DateTime DeleteTime { get; set; }
        [Required]
        public Nullable<bool> GoodsState { get; set; }
    }
}