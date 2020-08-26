using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace CargoTaxi.Data.Repozitories
{
    public class ClientRepozitoriy : IClientRepozitoriy
    {
        public List<ApplicationUser> GetAllClients()
        {
            using (var ctx = new TaxiDbContext())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                var roleId = ctx.Roles.SingleOrDefault(m => m.Name == "Client").Id;

                //var allUsers1 = ctx.Users.Include(x => x.Cars).Include(x => x.Orders).Include(x => x.Roles).ToList();
                var allUsers = ctx.Users.Include(x => x.Cars).Include(x => x.Orders).Include(x => x.Roles);
                var allClients = allUsers.Where(u => u.Roles.Any(r => r.RoleId == roleId)).ToList();

                return allClients;
            }
        }

        public void DeleteClient(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var user = ctx.Users.Where(x => x.Id == id.ToString()).FirstOrDefault();
                //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                //userManager.RemoveFromRole(user.Id, "");
                ctx.Users.Remove(user);
                ctx.SaveChanges();
            }
        }

        public void CreateOrder(Order order, string id)//, 
        {
            using (var ctx = new TaxiDbContext())
            {
                var clientInDb = ctx.Users.Where(x => x.Id == id).FirstOrDefault();
                ctx.Orders.Add(order);
                clientInDb.Orders.Add(order);
                ctx.SaveChanges();
            }
        }


        public void EditClientProfile(ApplicationUser client)
        {
            using (var ctx = new TaxiDbContext())
            {
                var clientInBd = ctx.Users.Where(x => x.Id == client.Id).FirstOrDefault();
                clientInBd.FirstName = client.FirstName;
                clientInBd.LastName = client.LastName;
                clientInBd.PhoneNumber = client.PhoneNumber;

                ctx.SaveChanges();
            }
        }

        public List<Order> GetMyAllOrders(string id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var allOrders = ctx.Orders.Include(x => x.Category).Include(x => x.Car).Include(x=>x.Client).Where(x => x.ClientId == id).ToList();
                var allOrders1=ctx.Orders.Where(x => x.ClientId == id).ToList();
                return allOrders;
            }
        }
    }
}
