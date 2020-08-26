using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class CarCategoryModel
    {
        public int Id { get; set; }
        public EnumCategories Name { get; set; }
        public double LoadTonCapacity { get; set; }
        public double WidthCargoSpace { get; set; }
        public double HeightCargoSpace { get; set; }
        public double LengthCargoSpace { get; set; }
        public IList<CarModel> Cars { get; set; }
        public CarCategoryModel()
        {
            Cars = new List<CarModel>();
        }
    }
}
