using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class RFQ
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuoteRequestNo { get; set; }

        [Required]
        [Display(Name = "Container Type")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Pick-Up Depot")]
        public string PUDepot { get; set; }

        [Display(Name = " Request Date")]
        public DateTime SysDate { get; set; }
        [Required]
        [Display(Name = "Delivery Street Number")]
        public string DelStreetNum { get; set; }
        [Required]
        [Display(Name = "Delivery Street Name")]
        public string DelStreetName { get; set; }
        [Required]
        [Display(Name = "Delivery Area")]
        public string DelArea { get; set; }
        [Required]
        [Display(Name = "Delivery City")]
        public string DelCity { get; set; }
        [Required]
        [Display(Name = "Delivery Post-Code")]
        [StringLength(4)]
        public string DelCode { get; set; }
        [Required]
        [Display(Name = "Special Instructions")]
        public string Instruct { get; set; }
        public double price { get; set; }
        public string Email { get; set; }
        public double CalcTotal()
        {
            double total = 0;

            if (DelCity == "Durban" && Size == "6m")
            {
                total = 4000 + 2000;
            }
            else if (DelCity == "Durban" && Size == "12m")
            {
                total = 4000 + 4000;
            }
            else if (DelCity == "Durban" && Size == "bulk")
            {
                total = 4000 + 6000;
            }

            if (DelCity == "Johannesburg" && Size == "6m")
            {
                total = 7000 + 2000;
            }
            else if (DelCity == "Johannesburg" && Size == "12m")
            {
                total = 7000 + 4000;
            }
            else if (DelCity == "Johannesburg" && Size == "bulk")
            {
                total = 7000 + 6000;
            }
            if (DelCity == "Cape Town" && Size == "6m")
            {
                total = 9000 + 2000;
            }
            else if (DelCity == "Cape Town" && Size == "12m")
            {
                total = 9000 + 4000;
            }
            else if (DelCity == "Cape Town" && Size == "bulk")
            {
                total = 9000 + 6000;
            }
            return total;
        }
    }
}