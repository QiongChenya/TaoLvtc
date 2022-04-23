using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class SoldTables//我卖出的商品
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
        public DateTime SellTime { get; set; }//卖出时间
        [Required]
        public Nullable<bool> GoodsState { get; set; }
    }
}