using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using CargoTaxi.Data.Utils;

namespace CargoTaxi.Data.Repozitories
{
    public class CarRepository : ICarRepository
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
                var allCars = ctx.Cars.Include(x => x.Driver).Include(x => x.Category).Include(x => x.Orders).OrderBy(x => x.Driver.LastName).ToList();

                return allCars;
            }
        }

        public Car GetCarById(int? id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var car = ctx.Cars.Include(x => x.Driver).Include(x => x.Category).Include(x => x.Orders).Where(x => x.Id == id).FirstOrDefault();
                return car;
            }
        }

        public Car GetCarByRegisterNumber(string number)
        {
            using (var ctx = new TaxiDbContext())
            {
                var car = ctx.Cars.Include(x => x.Driver).Include(x => x.Category).Include(x => x.Orders).Where(x => x.RegistrNumber == number).FirstOrDefault();
                return car;
            }
        }

        public List<Car> GetCarsForAsign(DateTime date, EnumDayParts part, int? categoryId)
        {    
            using (var ctx = new TaxiDbContext())
            {
                var cars = ctx.Cars.Include(x => x.Orders)
                    .Include(x => x.Category)
                    .Include(x => x.Driver)
                    .Where(x => x.CategoryId == categoryId).ToList();
                var cars1 = cars.Where(x => x.Orders.Any(y => y.Date != date)).Where(x => x.IsLoad == true).ToList();
                var cars2 = cars.Where(x => x.Orders.Any(y => y.Date == date)).Where(x => x.IsLoad == true).Where(x=>x.Driver.IsActiveDriver)
                    .ToList();
                var cars3 = cars.Where(x => !x.Orders.Any(y => y.Date == date)).Where(x => x.IsLoad == true).ToList();
                var cars4 = cars.Where(x => x.Orders.All(y => y.Date == date))
                    .Where(x => !x.Orders.Any(r => r.PartOfDay == part)).Where(x => x.IsLoad == true)
                    //.Where(x=>x.Orders.Any(r=> r.IsDone == false))
                    //.Where(x=>!x.Orders.Any(r=>r.PartOfDay==part))

                    //.Where(x=>x.Orders.All(y=>y.Date > date.Date))                  
                    //.Where(x => x.IsLoad == false)
                    .ToList();
               cars1 = cars1.Union(cars2).Union(cars4).Union(cars3).ToList();
                
//                SELECT a.name, 
//          GROUP_CONCAT(b.title) books
//     FROM authors a
//LEFT JOIN books b ON b.author_id = a.id
//    WHERE a.age BETWEEN 30 AND 40
// GROUP BY a.name
//    LIMIT 10;
                return cars1;
            }

        }

    }
}




