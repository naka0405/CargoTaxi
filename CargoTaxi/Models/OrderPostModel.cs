using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class OrderPostModel
    {
        public int Id { get; set; }
       
        public string StartTime { get; set; }
        
        public string FinishTime { get; set; }
        
        public bool IsDone { get; set; }
    }
}