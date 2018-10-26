using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class NewBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingIds { get; set; }
        [Required]
        [Display(Name = "Pick up Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime pickupdate { get; set; }
        //******************Booking Details******************
        [Required]
        [Display(Name = "Client Name")]
        public string clientname { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        public string cellnum { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
        //*******************container details***********************
        [Required]
        [Display(Name = "Container Number ")]
        public string ConNum { get; set; }
        [Required]
        [Display(Name = "Container Type")]
        public string ConType { get; set; }
        [Required]
        [Display(Name = "Container Size")]
        public string Size { get; set; }
        [Display(Name = "Special Instructions")]
        public string specInstruct { get; set; }
        public string testtext { get; set; }
        public double two { get; set; }
        public string Distance { get; set; }

        [Display(Name = "Final")]
        public double final { get; set; }
        public string Collection { get; set; }
        public string Dropoff { get; set; }
        public string priorty { get; set; }
        public string est { get; set; }
        public double estTime { get; set; }
        //collection
        public string news { get; set; }
        //drop off
        public string newss { get; set; }
        //Flag  
        public bool Booked{ get; set; }

        [Display(Name = "VAT")]
        public double vat { get; set; }

    }
}