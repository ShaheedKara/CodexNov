using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class NewContainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContainerID { get; set; }

        public string ContainerNumber { get; set; }
        public string ContainerSize { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime PickUpTime { get; set; }
        public string Priority { get; set; }

    }
}