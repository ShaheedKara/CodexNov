using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class CalAmt
    {
        [Key]
        public int id { get; set; }

        public double? fuel { get; set; }
        //Percent
        public double? Rate { get; set; }
    }
}