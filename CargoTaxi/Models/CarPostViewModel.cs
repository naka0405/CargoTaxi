using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class CarPostViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string RegistrNumber { get; set; }

        public int? CategoryId { get; set; }
       // public CarCategoryViewModel Category { get; set; }
        public string DriverId { get; set; }
        public bool IsLoad{ get; set; }
       
    }
}