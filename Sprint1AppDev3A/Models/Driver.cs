using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint1AppDev3A.Models
{
    public class Driver
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; }
        [Required]
        [Display(Name = "Id Number")]
        [StringLength(10)]
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
        [Required]
        [Display(Name = "Availability")]
        public Boolean DriAvailable { get; set; }



    }
}