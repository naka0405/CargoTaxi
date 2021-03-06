﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class CarViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string RegistrNumber { get; set; }

        public int? CategoryId { get; set; }
        public CarCategoryViewModel Category { get; set; }
        public string DriverId { get; set; }
        public UserViewModel Driver { get; set; }

        public IList<OrderViewModel> Orders { get; set; }
        public bool IsLoad { get; set; }

        public CarViewModel()
        {
            IsLoad = false;
            Orders = new List<OrderViewModel>();
        }
    }
}