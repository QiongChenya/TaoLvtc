using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLvtc.Models
{
    public class Verifications
    {
        [Key]
        [Required]
        public string Phone_Number { get; set; }
        [Required]
        public int VerificationCode { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        [Required]
        public Nullable<bool> State { get; set; }
        [Required]
        public int NumberOfSends { get; set; }
    }
}