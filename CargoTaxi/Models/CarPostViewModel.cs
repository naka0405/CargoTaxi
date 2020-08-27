using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class CarPostViewModel
    {      
        public string RegistrNumber { get; set; }

        public int? CategoryId { get; set; }
        //public CarCategoryViewModel Category { get; set; }
        public string DriverId { get; set; }
       // public UserViewModel Driver { get; set; }
       
    }
}