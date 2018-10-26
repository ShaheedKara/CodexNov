using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sprint1AppDev3A.Models
{
    public class DriverCheckIn
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckID { get; set; }



        [Display(Name = "Driver Name")]
        public string DriverEmail { get; set; }

        public string TimeStamp { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Additional comments")]
        public string Comment { get; set; }
        public string job { get; set; }




        public void getTime()
        {
            TimeStamp = DateTime.Now.ToString();
        }


        //async Task<string> RestTimer()
        //{
        //    await Task.Delay(3600000);
        //    return "StandBy";
        //}

       
        


       }
        
    }
