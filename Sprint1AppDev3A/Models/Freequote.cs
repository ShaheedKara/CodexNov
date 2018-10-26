using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint1AppDev3A.Models
{
    public class Freequote : IValidatableObject
    {
    

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (CollectionDate > deliveryDate)
            {
                results.Add(new ValidationResult("Pick up date must be before drop of date", new[] { "CollectionDate" }));
            }

            if (deliveryDate <= CollectionDate)
            {
                results.Add(new ValidationResult("drop of date must be after pick up date", new[] { "deliveryDate" }));
            }

            return results;
        }




        [Key]
        public int freeQuote { get; set; }
        [Required]
        [Display(Name = "Consumer Name")]
        public string ConsumerName { get; set; }
        [Required]
        [Display(Name = "Email ")]
        public string email{ get; set; }
        public string Size {get; set; }
        [Required]
        [Display(Name ="Weight")]
        public double weight { get; set; }
        //public string DelStreetNum { get; set; }
        //public string DelStreetName { get; set; }
        //public string DelArea { get; set; }
        //public string DelCity { get; set; }
        //public string DelCode { get; set; }
        //public string ColStreetNum { get; set; }
        //public string ColStreetName { get; set; }
        //public string ColArea { get; set; }
        //public string ColCity { get; set; }
        //public string ColCode { get; set; }
        [Required]
        [Display(Name = " Collection date ")]
        
        public DateTime CollectionDate { get; set; }
        [Required]
        [Display(Name = "Delivery date ")]
        public DateTime deliveryDate { get; set; }
        [Required]
        [Display(Name = "Cellphone number")]
        public string contactCell { get; set; }
        [Required]
        [Display(Name = "Work number")]
        public string contactwork { get; set; }
        public string testtext { get; set; }
        public double two { get; set; }
        public string Collection { get; set; }
        public string Dropoff { get; set; }
        [Display(Name = "Final Amount")]
        public double finna { get; set; }


        //public string address()
        //{
        //    string c = ColStreetNum + " "+ ColStreetName + " " + ColCity;

        //    return c;
        //}

    }
}