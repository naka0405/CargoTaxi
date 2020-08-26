using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoTaxi.Data.Repozitories
{
    public class ClientHelperRepozitory : IClientHelper
    {
        public List<CarCategory> GetAllCategory()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allCategories = ctx.CarCategories.ToList();
                return allCategories;
            }
        }

        public CarCategory GetCarCategoryById(int? id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var carCategoryInBd = ctx.CarCategories.Where(x => x.Id == id).FirstOrDefault();
                return carCategoryInBd;
            }
        }

        public Car GetCarById(int? id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var carInBd = ctx.Cars.Where(x => x.Id == id).FirstOrDefault();
                return carInBd;
            }
        }

        public ApplicationUser GetClientById(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var clientInBd = ctx.Users.Where(x => x.Id == id).FirstOrDefault();
                return clientInBd;
            }
        }

    }
}
