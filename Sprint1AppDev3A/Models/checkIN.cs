using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class checkIN
    {
        [Required]
        [Display(Name = "Employee ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = " Sign In Date  &  Time")]
        public DateTime CheckInDate { get; set; }
        public string name { get; set; }
    }
}