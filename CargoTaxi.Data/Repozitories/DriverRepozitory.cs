using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace CargoTaxi.Data.Repozitories
{
    public class DriverRepozitory : IDriverRepozitoriy
    {
        public ApplicationUser GetDriverById(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                // var roleStore = new RoleStore<IdentityRole>(ctx);
                // var roleMngr = new RoleManager<IdentityRole>(roleStore);

                //var role = roleMngr.FindByName("Driver");
                //var roleId = role.Id;
                var driver = ctx.Users.Where(x => x.Id == id)
                    .FirstOrDefault();
                return driver;
            }
        }

        public ApplicationUser GetDriverByEmail(string email)
        {
            using (var ctx = new TaxiDbContext())
            {
                var driver = ctx.Users.Where(x => x.UserName == email)
                    .FirstOrDefault();
                return driver;
            }
        }
        public void ChangeOrderStatus(OrderPropForUpdate order)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orderInDb = ctx.Orders.Include(x => x.Car).Include(x => x.Category).Where(x => x.Id == order.Id).FirstOrDefault();
                orderInDb.StartTime = order.StartTime;
                orderInDb.FinishTime = order.FinishTime;
                orderInDb.IsDone = order.IsDone;
                ctx.SaveChanges();
            }
        }



        public List<Order> GetMyDoneOrders(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var myDoneOrders = ctx.Orders.Include(x => x.Car.Driver).Include(c => c.Category).Include(x => x.Client).Where(x => x.Car.DriverId == id).Where(x => x.IsDone == true).ToList();
                return myDoneOrders;
            }
        }

        public List<Order> GetMyOrders(string id, DateTime? startDate, DateTime? finishDate)
        {
            using (var ctx = new TaxiDbContext())
            {
                if (startDate == null || finishDate == null)
                {
                    startDate = DateTime.MinValue;
                    finishDate = DateTime.MaxValue;
                }
                var myOrders = ctx.Orders.Include(x => x.Car.Driver).Include(c => c.Category).Include(x => x.Client).Where(x => x.Car.DriverId == id).Where(x => x.Date >= startDate && x.Date <= finishDate).ToList();
                return myOrders;
            }
        }

        public List<Order> GetOrdersForNextWeek(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var today = DateTime.Now;
                var dayForAWeek = today + TimeSpan.FromDays(7);
                var myOrders = ctx.Orders.Include(x => x.Car.Driver).Include(c => c.Category).Include(x => x.Client).Where(x => x.Car.DriverId == id).Where(x => x.Date >= today && x.Date <= dayForAWeek).ToList();
                return myOrders;
            }
        }

        public List<Order> GetTodayOrders(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var myOrders = ctx.Orders.Include(x => x.Car.Driver).Include(c => c.Category).Include(x => x.Client).Where(x => x.Car.DriverId == id).Where(x => x.Date == DateTime.Today).ToList();
                return myOrders;
            }
        }

        public List<Order> GetLastOrders(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var myOrders = ctx.Orders.Include(x => x.Car.Driver).Include(c => c.Category).Include(x => x.Client).Where(x => x.Car.DriverId == id).OrderByDescending(x => x.Date).Take(5).ToList();
                return myOrders;
            }
        }

        public List<Order> GetNotDoneOrders(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var myOrders = ctx.Orders.Include(x => x.Car.Driver).Include(c => c.Category).Include(x => x.Client).Where(x => x.Car.DriverId == id).Where(x => x.IsDone == false).ToList();//x.Date == DateTime.Today&&
                return myOrders;
            }
        }

        public void CreateDriver(ApplicationUser driver)//(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var user = ctx.Users.Where(x => x.Id == driver.Id).FirstOrDefault();
                user.DriverLicense = driver.DriverLicense;
                user.IsActiveDriver = driver.IsActiveDriver;
              
                var role = ctx.Roles.SingleOrDefault(m => m.Name == "Driver");
                //var user1 = ctx.Users.Where(x => x.Email == driver.Email).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                //var password = "ad46D_ewr3";
                //driver.UserName = driver.Email;

                if (user != null)
                {
                    if (!userManager.IsInRole(user.Id, "Driver"))
                    {
                        userManager.AddToRole(user.Id, "Driver");                        
                    }
                }
                ctx.SaveChanges();

            }
        }





        public void UpdateDriver(ApplicationUser driver)
        {
            using (var ctx = new TaxiDbContext())
            {
                var driverInBd = ctx.Users.Where(x => x.Id == driver.Id).FirstOrDefault();
                driverInBd.FirstName = driver.FirstName;
                driverInBd.LastName = driver.LastName;
                driverInBd.PhoneNumber = driver.PhoneNumber;
                driverInBd.IsActiveDriver = driver.IsActiveDriver;
                driverInBd.DriverLicense = driver.DriverLicense;

                ctx.SaveChanges();
            }
        }


        public void DeactivateDriver(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var user = ctx.Users.Where(x => x.Id == id.ToString()).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                userManager.RemoveFromRole(user.Id, "Driver");
            }
        }

        public List<ApplicationUser> GetAllDrivers()
        {
            using (var ctx = new TaxiDbContext())
            {
                var roleId = ctx.Roles.SingleOrDefault(m => m.Name == "Driver").Id;

                //var allUsers1 = ctx.Users.Include(x => x.Cars).Include(x => x.Orders).Include(x => x.Roles).ToList();
                var allUsers = ctx.Users.Include(x => x.Cars).Include(x => x.Orders).Include(x => x.Roles);
                var allDrivers = allUsers.Where(u => u.Roles.Any(r => r.RoleId == roleId)).ToList();

                return allDrivers;
            }
        }

    }
}
