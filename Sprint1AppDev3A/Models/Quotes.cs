using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class Quotes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int quoteNo { get; set; }
        [Required]
        [Display(Name = "Wage")]
        public double tWage { get; set; }
        [Required]
        [Display(Name = "Toll Fees")]
        public double TollFees { get; set; }
        [Required]
        [Display(Name = "Petty Cash")]
        public double PettyCash { get; set; }
        [Required]
        [Display(Name = "Fuel Price")]
        public double FuelPrice { get; set; }
        //  [Required]
        // [Display(Name = "Expense")]
        // public double Texpenses { get; set; }
        public string testtext { get; set; }
        public double two { get; set; }
       
        public double finalamt { get; set; }
        //this method will be added to our calc total method below to give final price

        public double calcExp()
        {
            double expense;
            expense = tWage + TollFees + PettyCash + FuelPrice;
            return expense;
        }
        public int QuoteRequestNo { get; set; }
        public virtual RFQ RFQs { get; set; }
    }
}