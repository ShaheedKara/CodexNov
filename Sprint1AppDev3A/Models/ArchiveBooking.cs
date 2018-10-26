using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class ArchiveBooking
    {
        [Key]
        public int PreId { get; set; }
        public string RefNum { get; set; }
        public string ContainerSize { get; set; }
        public string pickupLocation { get; set; }
        public string dropoffLocation { get; set; }
        public string transportType { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int transit { get; set; }
        public bool Booked { get; set; }
        public int id { get; set; }
    }
}