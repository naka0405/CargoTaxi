using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class CarsForOrderViewModel
    {
        public List<CarViewModel> Cars { get; set; }
        public string OrderNumber { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string StartTime { get; set; }
    }
}