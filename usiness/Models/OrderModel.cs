using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string StartAdress { get; set; }
        public string FinishAdress { get; set; }
        public bool IsDone { get; set; }

        public int? CarCategoryId { get; set; }
        public CarCategoryModel Category { get; set; }
        public int? CarId { get; set; }
        public CarModel Car { get; set; }
        public string ClientId { get; set; }
        public UserModel Client { get; set; }
    }
}
