using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class DriverPostViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DriverLicense { get; set; }
       
        public IList<CarViewModel> Cars { get; set; }
        public bool IsActiveDriver { get; set; }

        public DriverPostViewModel()
        {           
            Cars = new List<CarViewModel>();
        }
    }
}