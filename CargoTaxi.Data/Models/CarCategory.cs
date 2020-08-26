using CargoTaxi.Data.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Models
{
    public class CarCategory
    {
        public int Id { get; set; }

       //[Column(TypeName = "nvarchar(20)")]
        public EnumCategories Name { get; set; }
        public double LoadTonCapacity { get; set; }       
        public double WidthCargoSpace { get; set; }
        public double HeightCargoSpace { get; set; }
        public double LengthCargoSpace { get; set; }
        public IList<Car> Cars { get; set; }
        public CarCategory()
        {
            Cars = new List<Car>();
        }
    }
}
