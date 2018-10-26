using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class PreSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PreId { get; set; }
        public string RefNum { get; set; }
        [Required]
        public string ContainerSize { get; set; }
        [Required]
        [Display(Name = "please select pick up Location ")]
        public string pickupLocation { get; set; }
        [Required]
        [Display(Name = "please select drop off Location ")]
        public string dropoffLocation { get; set; }
        public string transportType { get; set; }
        [Required]
        [Display(Name = "Pick up Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime start { get; set; }
        [Required]
        [Display(Name = "Drop off Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime end { get; set; }
        public int transit { get; set; }
        public bool Booked{ get; set; }
        public string genRefNum()
        {
            string refNum = "";
            refNum = "OLL" + PreId;
            return refNum;
        }
        public int id { get; set; }
        public virtual Resource Resources { get; set; }
    }
}