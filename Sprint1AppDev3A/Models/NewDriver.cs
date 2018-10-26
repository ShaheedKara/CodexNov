using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class NewDriver
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; }
        [Required]
        [Display(Name = "Id Number")]
        [StringLength(13)]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string DriverFullName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(10)]
        public string contactNumber { get; set; }        
        [Display(Name = "Status")]
        public virtual List<Resource> Resources { get; set; }
        public virtual List<AssignMk2> AssignMk2 { get; set; }

    }
}