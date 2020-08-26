using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Repozitories
{
    public class CarRepozitory : ICarRepozitory
    {
        public void CreateCar(Car car)
        {
            using (var ctx = new TaxiDbContext())
            {
                ctx.Cars.Add(car);
                ctx.SaveChanges();
            }
        }

        public void DeleteCar(int id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var carInDb = ctx.Cars.Where(x => x.Id == id).FirstOrDefault();
                ctx.Cars.Remove(carInDb);
                ctx.SaveChanges();
            }
        }

        public void EditCar(Car car)
        {
            using (var ctx = new TaxiDbContext())
            {
                var carInDb = ctx.Cars.Include(x => x.Driver).Include(x => x.Category).Where(x => x.Id == car.Id).FirstOrDefault();
                carInDb.CategoryId = car.CategoryId;
                carInDb.DriverId = car.DriverId;
                carInDb.RegistrNumber = car.RegistrNumber;
                carInDb.IsLoad = car.IsLoad;
                carInDb.Orders = car.Orders;

                ctx.SaveChanges();
            }
        }

        public List<Car> GetAllCars()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allCars = ctx.Cars.Include(x => x.Driver).Include(x => x.Category).Include(x => x.Orders).ToList();
                return allCars;
            }
        }

        public Car GetCarById(int id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var car = ctx.Cars.Include(x => x.Driver).Include(x => x.Category).Include(x => x.Orders).Where(x => x.Id == id).FirstOrDefault();
                return car;
            }

        }
    }
}
    

