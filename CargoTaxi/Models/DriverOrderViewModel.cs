using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class DriverOrderViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }        
        public string Number { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string StartAdress { get; set; }
        public string FinishAdress { get; set; }
        public bool IsDone { get; set; }       
        public string CarCategory { get; set; }
        public string Car { get; set; }
        public string ClientPhone { get; set; }       
    }
}