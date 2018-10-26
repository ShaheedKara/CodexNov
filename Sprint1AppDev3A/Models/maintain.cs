using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1AppDev3A.Models
{
   public class maintain
    {
        [Key]
        public int MaintainID { get; set; }

        public int TruckId { get; set; }


        [Required(ErrorMessage = "please enter trailer ID")]
        [Display(Name = "Trailer ID")]
        public int TrailerID { get; set; }

        [Required(ErrorMessage = "please enter maintenance description")]
        [Display(Name = "Maintenance Description")]
        public string MaintainDes { get; set; }

        [Required(ErrorMessage = "please enter monthly maintenance cost")]
        [Display(Name = "Maintenance Cost")]
        public double MaintainPrice { get; set; }

        [Required]
        [Display(Name = "Date off Maintenance")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Mdate { get; set; }

        [Required(ErrorMessage = "please enter technician name")]
        [Display(Name = "Technician Name")]
        public string MTechnician { get; set; }
    }
}
