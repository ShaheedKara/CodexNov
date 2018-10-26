using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Truck
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TruckId { get; set; }

        [Required(ErrorMessage = "please select size of Trailer")]
        [Display(Name = "Trailer Size")]
        public string TrailerSize { get; set; }

        [Required(ErrorMessage = "please select make of truck")]
        [Display(Name = "Truck make")]
        public string make { get; set; }

        [Required(ErrorMessage = "please enter model of truck")]
        [Display(Name = "Truck model")]
        public string model { get; set; }

        [Required(ErrorMessage = "please Vehicle Identification Number of truck")]
        [Display(Name = "Vehicle Identification Number")]
        [StringLength(17)]
        public string vin { get; set; }

        [Required(ErrorMessage = "please enter registration of truck")]
        [Display(Name = "Truck Registration")]
        public string reg { get; set; }

        [Required(ErrorMessage = "please declare availability")]
        [Display(Name = "Is Available")]
        public Boolean Available { get; set; }

        


        //public void SizeCheck()
        //{
        //    if (TrailerSize == "6m")
        //    {
        //        reg = reg + "-S6M";
        //    }
        //    else
        //    {
        //        reg = reg + "-S12M";
        //    }
        //}
    }

}
