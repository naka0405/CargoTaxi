using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string DriverLicense { get; set; }

        public IList<OrderModel> Orders { get; set; }
        public IList<CarModel> Cars { get; set; }
        public bool IsActiveDriver { get; set; }

        public UserModel()
        {            
            Orders = new List<OrderModel>();
            Cars = new List<CarModel>();
        }
    }
}
