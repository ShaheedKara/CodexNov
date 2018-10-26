using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class CheckOut2
    {
        [Required]
        [Display(Name = "Employee ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Sign Out Date  &  Time")]
        public DateTime CheckOutDate { get; set; }
        public string name { get; set; }
        [Display(Name = " Sign Out Date  &  Time")]
        public DateTime CheckinDate { get; set; }
    }
}