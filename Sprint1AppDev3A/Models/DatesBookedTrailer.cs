using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class DatesBookedTrailer
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int TraiKey { get; set; }

        //public int TrailID { get; set; }
        //[ForeignKey("TrailID")]
        //public NewTrailer TrailerId { get; set; }

        //public DateTime PickUpDate { get; set; }
        //public DateTime DropOffDate { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TraiKey { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public virtual List<NewTrailer> NewTrailers { get; set; }
        public int TrailID { get; set; }
    }
   
}

