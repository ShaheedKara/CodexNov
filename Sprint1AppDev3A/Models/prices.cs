using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1AppDev3A.Models
{
    public class prices
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Rate")]
        public double? rate { get; set; }
        [Display(Name = "Trailer(6)")]
        public double? six { get; set; }
        [Display(Name = "Trailer(12)")]
        public double? twelve { get; set; }
        [Display(Name = "Dry Container")]
        public double? dry { get; set; }
        [Display(Name = "Tank Container")]
        public double? tank { get; set; }
        [Display(Name = "Refrigerated Container")]
        public double? refridge { get; set; }
        //[Display(Name = "Container Type")]
        //public double? perishables { get; set; }
    }
}
