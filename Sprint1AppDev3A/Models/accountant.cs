using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class accountant
    {
        [Key]

        public int id { get; set; }
        [Required(ErrorMessage = "Please enter monthly insurance for Ocean land Logistics")]
        [Display(Name = "Monthly Insurance")]
        public double Insurance { get; set; }
        [Required(ErrorMessage = "Please enter monthly Cellphone maintence cost")]
        [Display(Name = "Monthly Cellphone Maintence cost")]
        public double mobileCost { get; set; }
        [Required(ErrorMessage = "Please enter monthly Telephone maintence cost")]
        [Display(Name = "Monthly Telephone Maintence cost")]
        public double telephoneCost { get; set; }

        [Required(ErrorMessage = "Please enter monthly water and lights cost")]
        [Display(Name = "Monthly Water and Lights ")]
        public double electricity { get; set; }

        [Required(ErrorMessage = "Please enter monthly rent")]
        [Display(Name = "Monthly Rent")]
        public double rent { get; set; }


        [Required(ErrorMessage = "Please enter cost of monthly office supplies ")]
        [Display(Name = "Monthly office supplies cost")]
        public double officeSupplies { get; set; }

        [Required(ErrorMessage = "Please enter cost of monthly sanitary supplies ")]
        [Display(Name = "Monthly sanitary supplies cost")]
        public double sanitarySupplies { get; set; }



        [Display(Name = " Total Monthly Fee ")]
        public double month { get; set; }

        
        public double monthly()
        {
            double tot = tot = Insurance + mobileCost + telephoneCost + rent
                 + officeSupplies + electricity + sanitarySupplies;
            return tot;
        }
    }
}