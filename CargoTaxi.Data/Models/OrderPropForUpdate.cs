using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Models
{
    public class OrderPropForUpdate
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public bool IsDone { get; set; }
    }
}
