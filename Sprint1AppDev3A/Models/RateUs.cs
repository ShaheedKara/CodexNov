using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint1AppDev3A.Models
{
    public class RateUs
    {
        public RateUs()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int rateId { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
    }
}