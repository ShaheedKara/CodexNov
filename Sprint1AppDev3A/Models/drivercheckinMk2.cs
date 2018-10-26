using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class drivercheckinMk2
    {
        [Key]
        public int drivercheckin { get; set; }
        public string email { get; set; }
        public DateTime dateandtime { get; set; }
      
        public string address { get; set; }
        public string lognlat { get; set; }
        public string comment { get; set; }
        public string testtext { get; set; }
        public string testtexts { get; set; }

    }
}