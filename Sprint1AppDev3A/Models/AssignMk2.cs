using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class AssignMk2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
        public int TruckId { get; set; }
        public virtual NewTruck NewTruck { get;set; }
        public int DriverId { get; set; }
        public virtual NewDriver NewDrivers { get; set; }
        public int TrailerId { get; set; }
        public virtual NewTrailer NewTrailers { get; set; }
        public int BookingIds { get; set; }
        public virtual NewBooking NewBookings { get; set; }
    }
}