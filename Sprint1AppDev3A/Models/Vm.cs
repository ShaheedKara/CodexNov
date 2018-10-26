using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Vm
    {
        [Key]
        public int QuoteRequestNo { get; set; }
        public string Email { get; set; }
        public string Deladdress { get; set; }
        public DateTime date { get; set; }
        public string Instructions { get; set; }
        public double endAmt { get; set; }
    }
}