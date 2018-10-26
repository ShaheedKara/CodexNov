using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Sprint1AppDev3A.Models

{
    public class Assign
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignID { get; set; }

        public int TrucksID { get; set; }
        [ForeignKey("TrucksID")]
        public Truck TruckId { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Bookings BookingIds { get; set; }

        public int DriveID { get; set; }
        [ForeignKey("DriveID")]
        public Driver DriverId { get; set; }

       
    }
}