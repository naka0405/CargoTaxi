using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class UserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DriverLicense { get; set; }

        public IList<OrderViewModel> Orders { get; set; }
        public IList<CarViewModel> Cars { get; set; }
        public bool IsActiveDriver { get; set; }

        public UserViewModel()
        {
            Orders = new List<OrderViewModel>();
            Cars = new List<CarViewModel>();
        }
    }
}