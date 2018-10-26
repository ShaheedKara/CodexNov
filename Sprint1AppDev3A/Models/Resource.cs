 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Resource
    {
        [Key]
        public int id  { get; set; }
        public string statusResource { get; set; }
        public string TrailerSize { get; set; }
        public int TrailerId { get; set; }
        public virtual NewTrailer NewTrailer { get; set; }
        public int TruckId { get; set; }
        public virtual NewTruck NewTrucks { get; set; }
        public int DriverId { get; set; }
        public virtual NewDriver NewDrivers { get; set; }
        public virtual List<PreSchedule> PreSchedule { get; set; }
    }
}