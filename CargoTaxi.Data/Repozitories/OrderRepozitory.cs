using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Repozitories
{
    public class OrderRepozitory : IOrderRepozitoriy
    {
        //public void CreateOrder(Order order)
        //{
        //    using (var ctx = new TaxiDbContext())
        //    {
        //        ctx.Orders.Add(order);
        //        ctx.SaveChanges();
        //    }
        //}

        public void DeleteOrder(int id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orderInDb = ctx.Orders.Where(x => x.Id == id).FirstOrDefault();
                ctx.Orders.Remove(orderInDb);
                ctx.SaveChanges();
            }
        }

        public void EditOrder(Order order)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orderInDb = ctx.Orders.Include(x => x.Car).Include(x => x.Category).Where(x => x.Id == order.Id).FirstOrDefault();
                orderInDb.Number = order.Number;
                orderInDb.StartAdress = order.StartAdress;
                orderInDb.FinishAdress = order.FinishAdress;
                orderInDb.IsDone = order.IsDone;
                orderInDb.CarId = order.CarId;
                orderInDb.CarCategoryId = order.CarCategoryId;
                ctx.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allOrders = ctx.Orders.Include(x => x.Client).Include(x => x.Car).Include(x=>x.Category).ToList();
                return allOrders;
            }
        }

        public List<Order> GetNotDoneOrders()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allOrders = ctx.Orders.Include(x => x.Client).Include(x => x.Car).Where(x=>x.IsDone==false).ToList();
                return allOrders;
            }
        }

        public Order GetOrderByCarRegistrNumber(string number)
        {
            using (var ctx = new TaxiDbContext())
            {
                var order = ctx.Orders.Include(x => x.Car).Where(x => x.Car.RegistrNumber == number).FirstOrDefault();
                return order;
            }
        }

        public Order GetOrderByDriverTel(string tel)
        {
            using (var ctx = new TaxiDbContext())
            {
                var order = ctx.Orders.Include(x => x.Car.Driver).Where(x => x.Car.Driver.PhoneNumber == tel).FirstOrDefault();
                return order;
            }
        }

        public Order GetOrderById(int id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var order = ctx.Orders.Include(x => x.Client).Where(x => x.Id == id).FirstOrDefault();
                return order;
            }

        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>expression)
        {

        }
    }
}
