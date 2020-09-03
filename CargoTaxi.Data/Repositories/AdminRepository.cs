using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Repozitories
{
    public class AdminRepository : IAdminRepository
    {
        public void AssignCar(int orderId, int carId, string number)
        {
            using(var ctx=new TaxiDbContext())
            {
                var order = ctx.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            
                var car = ctx.Cars.Where(x => x.Id == carId).FirstOrDefault();
                order.Car = car;
                order.Number = number;
                ctx.SaveChanges();                
            }
        }

        public void CreateCar(Car car)
        {
            using (var ctx = new TaxiDbContext())
            {
                ctx.Cars.Add(car);
                ctx.SaveChanges();
            }
        }

        //public void CreateDriver(int id)
        //{
        //    using (var ctx = new TaxiDbContext())
        //    {
        //        var user = ctx.Users.Where(x => x.Id == id.ToString()).FirstOrDefault();
        //        var roleDriver = ctx.Roles.SingleOrDefault(m => m.Name == "Driver");
        //        var roleClient = ctx.Roles.SingleOrDefault(m => m.Name == "Client");
        //        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
        //        if (user != null)
        //        {
        //            userManager.AddToRole(user.Id, "Driver");
        //            userManager.RemoveFromRole(user.Id, "Client");
        //            user.Roles.Add(new IdentityUserRole { RoleId = roleDriver.Id });
        //            user.Roles.Remove(new IdentityUserRole { RoleId = roleClient.Id });
        //            ctx.SaveChanges();
        //        }
        //    }
        //}

        public void DeactivateDriver(int id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var user = ctx.Users.Where(x => x.Id == id.ToString()).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                userManager.RemoveFromRole(user.Id, "Driver");
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

        public void DeleteOrder(string number)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orderInDb = ctx.Orders.Where(x => x.Number ==number).FirstOrDefault();
                ctx.Orders.Remove(orderInDb);
                ctx.SaveChanges();
            }
        }
    }
}
