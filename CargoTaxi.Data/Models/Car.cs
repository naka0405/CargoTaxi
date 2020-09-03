using CargoTaxi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Models
{
    public class Car:ILoadable
    {
        public int Id { get; set; }
        public string RegistrNumber { get; set; }

        public int? CategoryId { get; set; }
        public CarCategory Category { get; set; }
        public string DriverId { get; set; }
        public ApplicationUser Driver { get; set; }

        public IList<Order> Orders { get; set; }
        public bool IsLoad { get; set ; }
        //public List<>

        public Car()
        {
            IsLoad = false;
            Orders = new List<Order>();
        }

    }
}
