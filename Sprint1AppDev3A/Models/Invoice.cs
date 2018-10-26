using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Invoice
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Enter Job Id:")]
        public int jobId { get; set; }
        [Display(Name = "Client Name:")]
        public string name { get; set; }
        [Display(Name = "Client Email:")]
        public string email { get; set; }
        [Display(Name = "Client Contact Number:")]
        public string number { get; set; }
        [Display(Name = "Pick up address:")]
        public string pickup { get; set; }
        [Display(Name = "Drop off address:")]
        public string dropoff { get; set; }

        [Display(Name = "Container Type:")]
        public string ConType { get; set; }


        [Display(Name = "Container Size:")]
        public string Size { get; set; }
        [Display(Name = "Total:")]
        public double total { get; set; }
        [Display(Name = "Vat:")]
        public double vattotal { get; set; }
        [Display(Name = "Net Total(incl Vat):")]
        public double net { get; set; }

    }
}