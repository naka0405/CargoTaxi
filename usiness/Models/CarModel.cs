using System.Collections.Generic;


namespace Business.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string RegistrNumber { get; set; }

        public int? CategoryId { get; set; }
        public CarCategoryModel Category { get; set; }
        public string DriverId { get; set; }
        public UserModel Driver { get; set; }

        public IList<OrderModel> Orders { get; set; }
        public bool IsLoad { get; set; }

        public CarModel()
        {           
            Orders = new List<OrderModel>();
        }
   }
}
