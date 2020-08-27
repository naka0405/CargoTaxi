using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class CarCategoryViewModel
    {
        public int Id { get; set; }
        public EnumCategories Name { get; set; }
        public double LoadTonCapacity { get; set; }
        public double WidthCargoSpace { get; set; }
        public double HeightCargoSpace { get; set; }
        public double LengthCargoSpace { get; set; }
        public IList<CarViewModel> Cars { get; set; }
        public CarCategoryViewModel()
        {
            Cars = new List<CarViewModel>();
        }
    }
}