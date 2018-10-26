using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuoteID { get; set; }

        [Required]
        [Display(Name = "Distance")]
        public double Distance { get; set; }
        [Required]
        [Display(Name = "FuelPrice")]
        public double FuelPrice { get; set; }
        [Required]
        [Display(Name = "Mark up")]
        public double Markup { get; set; }



        public double VAT { get; set; }
        public double CalcVAT()
        {
            VAT = (((Distance / 5) * FuelPrice) * Markup) * 0.15;
            return VAT;
        }


        public double CalcCost()
        {

            double Price;

            Price = (((Distance / 5) * FuelPrice) * Markup);
            Price = Price + VAT;

            return Price;
        }
        public double Final { get; set; }

        public int QuoteRequestNo { get; set; }
        public virtual RFQ RFQs { get; set; }
    }
}