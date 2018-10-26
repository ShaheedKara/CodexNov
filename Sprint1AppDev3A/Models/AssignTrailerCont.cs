using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class AssignTrailerCont
    {
        [Key]
        public int AssignId { get; set; }
        public int BookingIds { get; set; }
        public virtual List<NewBooking> NewBookings { get; set; }
        public int ContainerID { get; set; }
        public virtual List<NewContainer> NewContainers { get; set; }
        public int TrailerId { get; set; }
        public virtual List<TrailerMk2> TrailerMk2 { get; set; }
    }
}