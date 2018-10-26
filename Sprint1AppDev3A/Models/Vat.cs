using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Vat
    {
        [Key]
        public int ID { get; set; }
        public double? vat { get; set; }
        public double? exempt { get; set; }
        public double? standardRated { get; set; }
        public double? zeroRated { get; set; }
    }
}