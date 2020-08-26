using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Repozitories
{
    public class CarCategoryRepository : ICarCategoryRepozitory
    {
        

        public List<CarCategory> GetAllCategories()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allCategories = ctx.CarCategories.ToList();
                return allCategories;
            }
        }

        public CarCategory GetCategoryById(int? id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var carCategoryInBd = ctx.CarCategories.Include(x=>x.Cars).Where(x => x.Id == id).FirstOrDefault();
                return carCategoryInBd;
            }
        }
    }
}
