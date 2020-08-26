using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Repozitories
{
    public class DriverHelperRepozitory : IDriverHelper
    {
        public ApplicationUser GetDriverById(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(ctx);
                var roleMngr = new RoleManager<IdentityRole>(roleStore);

                var role = roleMngr.FindByName("Driver");
                var roleId = role.Id;
                var driver = ctx.Users
                    .Include(x => x.Roles.Select(r => r.RoleId == roleId))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                return driver;
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orderInDb = ctx.Orders.Include(x => x.Car).Include(x => x.Category).Where(x => x.Id == order.Id).FirstOrDefault();
                orderInDb.FinishTime = order.FinishTime;
                orderInDb.IsDone = order.IsDone;               
                ctx.SaveChanges();
            }
        }
    }
}
