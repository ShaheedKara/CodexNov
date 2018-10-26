using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class ArchiveNewBooking
    {
        [Key]
        public int BookingIds { get; set; }
        public DateTime pickupdate { get; set; }
        public string clientname { get; set; }
        public string cellnum { get; set; }
        public string email { get; set; }
        public string ConNum { get; set; }
        public string ConType { get; set; }
        public string Size { get; set; }
        public string specInstruct { get; set; }
        public string testtext { get; set; }
        public double two { get; set; }
        public string Distance { get; set; }
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
        public bool Booked { get; set; }
        public double vat { get; set; }
    }
}