using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class TrailerMk2
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrailerId { get; set; }
        [Required(ErrorMessage = "please enter registration of trailer")]
        [Display(Name = "Trailer Registration")]
        public string reg { get; set; }
        [Required(ErrorMessage = "please enter size of trailer")]
        [Display(Name = "Trailer Size")]
        public string TrailerSize { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        public DateTime exp { get; set; }
    }
}