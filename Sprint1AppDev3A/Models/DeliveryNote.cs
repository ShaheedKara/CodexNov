using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class DeliveryNote
    {
        [Key]
        public int NoteID { get; set; }
        public DateTime dateCreated { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string clientname { get; set; }

        [Required]
        [Display(Name = "Container Type")]
        public string ConType { get; set; }

        [Required]
        [Display(Name = "Container Size")]
        public string Size { get; set; }

        [Display(Name = "Special Instructions")]
        public string specInstruct { get; set; }
        [Required]
        [Display(Name = "Delivery Address")]
        public string Dropoff { get; set; }
    }
}