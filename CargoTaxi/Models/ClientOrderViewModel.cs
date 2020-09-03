using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class ClientOrderViewModel
    {
        public string Number { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"
            , ApplyFormatInEditMode = true)]       
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string StartAdress { get; set; }
        public string FinishAdress { get; set; }
        public string Category { get; set; }
        public string Car { get; set; }
        public string Client { get; set; }
        public string ClientPhone { get; set; }

        public ClientOrderViewModel(string notNumber= "не назначена")
        {
            Car = notNumber;
        }
    }

}