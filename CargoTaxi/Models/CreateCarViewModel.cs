using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class CreateCarViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string RegistrNumber { get; set; }
        public int? CategoryId { get; set; }       
        public string DriverId { get; set; }
        public bool IsLoad { get; set; }
        public SelectList Drivers { get; set; }
        public SelectList CarCategories { get; set; }
        public string Message { get; set; }
    }
}