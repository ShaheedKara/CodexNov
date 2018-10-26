using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class AssignViewModel
    {
        [Key]
        public int AssignID { get; set; }
        public string ClientName { get; set; }
        public string refNumber { get; set; }
        public string colCity { get; set; }
        public DateTime pickupDate { get; set; }
        public string delCity { get; set; }
        public DateTime dropoffDate { get; set; }
        public string truckReg { get; set; }
        public string driverName { get; set; }
        public string driverNum { get; set; }
        public string driverEmail { get; set; }
    }
}