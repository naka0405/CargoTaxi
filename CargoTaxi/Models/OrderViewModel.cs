using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class OrderViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Number { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"
           , ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string StartAdress { get; set; }
        public string FinishAdress { get; set; }
        public bool IsDone { get; set; }

       public int? CarCategoryId { get; set; }
        public CarCategoryViewModel Category { get; set; }
        public int? CarId { get; set; }
        public CarViewModel Car { get; set; }
        public string ClientId { get; set; }
        public UserViewModel Client { get; set; }
         }
}