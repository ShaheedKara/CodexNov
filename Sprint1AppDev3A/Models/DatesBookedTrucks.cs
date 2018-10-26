using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class DatesBookedTrucks
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int TrucKey { get; set; }

        //public int TruckID { get; set; }
        //[ForeignKey("TruckID")]
        //public NewTruck TrucksId { get; set; }

        //public DateTime PickUpDate { get; set; }
        //public DateTime DropOffDate { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrucKey { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public virtual List<NewTruck> NewTrucks { get; set; }
        public int TruckID { get; set; }
    }
    public class a
    {

       

    }
}

