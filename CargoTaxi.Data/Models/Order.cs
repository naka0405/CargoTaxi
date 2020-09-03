using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Models
{
    public class Order
    {
        public int Id { get;set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public EnumDayParts PartOfDay { get; set; }
        public string FinishTime { get; set; }
        public string StartAdress { get; set; }
        public string FinishAdress { get; set; }
        public bool IsDone { get; set; }

        public int? CarCategoryId { get; set; }
        public CarCategory Category { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }

    }
}
