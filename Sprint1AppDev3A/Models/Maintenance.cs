using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Maintenance
    {
        [Key]
        public int MaintainID { get; set; }

        [Required(ErrorMessage = "Please Select Vehicle")]
        [Display(Name = "Vehicle")]
        public string Vehicle { get; set; }

        [Required(ErrorMessage = "Please Enter Number Plate")]
        [Display(Name = "Registration (Number Plate)")]
        public string ID { get; set; }


        [Display(Name = "Maintenance Type  ")]
        public string MaintainCheckBox { get; set; }

        [Required(ErrorMessage = "Please Enter Description Of What Maintenance Was Done")]
        [Display(Name = "Maintenance Description")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Maintenance Cost")]
        [Display(Name = "Maintenance Cost")]
        public double MaintainPrice { get; set; }

        [Required]
        [Display(Name = "Date of Maintenance")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Mdate { get; set; }

        [Required(ErrorMessage = "Please Enter Maintenance Company name")]
        [Display(Name = "Company Name")]
        public string MCompany { get; set; }

        [Required(ErrorMessage = "Please Enter Mechanic / Technicians name")]
        [Display(Name = "Mechanic / Technician Name")]
        public string MTechnician { get; set; }


        public bool Service { get; set; }

        public bool Tyres { get; set; }

        public bool Other { get; set; }
        public string checkbox()
        {

            if (Service == true)
            {
                MaintainCheckBox = "Service";
            }
            if (Tyres == true)
            {
                MaintainCheckBox = "Tyres";
            }
            if (Other == true)
            {
                MaintainCheckBox = "Other";
            }
            return MaintainCheckBox;
        }
    }
}