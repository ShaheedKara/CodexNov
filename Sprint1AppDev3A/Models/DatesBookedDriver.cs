using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class DatesBookedDriver
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DriKey { get; set; }

        //public int DriveID { get; set; }
        //[ForeignKey("DriveID")]
        //public NewDriver DriverId  { get; set; }

        //public DateTime PickUpDate { get; set; }
        //public DateTime DropOffDate { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriKey { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public virtual List<NewDriver> NewDrivers { get; set; }
        public int DriveID { get; set; }
    }
    
}