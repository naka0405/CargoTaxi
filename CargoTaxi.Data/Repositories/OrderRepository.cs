using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Repozitories
{
    public class OrderRepository : IOrderRepository
    {
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

        public void UpdateOrderByDriver(Order order)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orderInDb = ctx.Orders.Include(x => x.Car).Include(x => x.Category).Where(x => x.Id == order.Id).FirstOrDefault();
                orderInDb.FinishTime = order.FinishTime;
                orderInDb.IsDone = order.IsDone;
                ctx.SaveChanges();
            }
        }
        
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
                var orderInDb = ctx.Orders.Include(x => x.Car).Include(x => x.Category).Include(x=>x.Client).Where(x => x.Id == order.Id).FirstOrDefault();
                orderInDb.Id = order.Id;
                orderInDb.StartAdress = order.StartAdress;
                orderInDb.StartTime = order.StartTime;
                orderInDb.Date = order.Date;
                orderInDb.FinishAdress = order.FinishAdress;
               // orderInDb.IsDone = order.IsDone;
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

        public List<Order> GetNotAssignOrders()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allOrders = ctx.Orders.Include(x => x.Client).Include(x => x.Car).Include(x => x.Category).Where(x => x.Car == null).Where(x=>x.Date>=DateTime.Today).OrderBy(x=>x.Date).ToList();
                return allOrders;
            }
        }

        public List<Order> GetNotDoneOrders()
        {
            using (var ctx = new TaxiDbContext())
            {
                var allOrders = ctx.Orders.Include(x => x.Client).Include(x => x.Car).Include(x => x.Category).Where(x=>x.IsDone==false).ToList();
                return allOrders;
            }
        }

        public List<Order> GetOrderByCarRegistrNumber(string number)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orders = ctx.Orders.Include(x => x.Car).Include(x=>x.Client).Include(x => x.Category).Where(x => x.Car.RegistrNumber == number).ToList();
                return orders;
            }
        }

        public List<Order> GetOrderByClientTel(string tel)
        {
            using (var ctx = new TaxiDbContext())
            {
                var orders = ctx.Orders.Include(x => x.Client).Include(x=>x.Category).Where(x => x.Client.PhoneNumber == tel).ToList();
                return orders;
            }
        }

        public Order GetOrderById(int id)
        {
            using (var ctx = new TaxiDbContext())
            {
                var order = ctx.Orders.Include(x => x.Client).Include(x => x.Category).Include(x=>x.Car).Where(x => x.Id == id).FirstOrDefault();
                return order;
            }
        }

        public List<Order>GetTodayOrders()
        {
            using (var ctx = new TaxiDbContext())
            {
                var orders = ctx.Orders.Include(x => x.Client).Include(x=>x.Car).Include(x=>x.Category).Where(x => x.Date == DateTime.Today).ToList();
                return orders;
            }
        }
        
        public List<Order> OrdersByDate(DateTime? startDate, DateTime? finishDate)
        {
            using (var ctx = new TaxiDbContext())
            {
                startDate = startDate == null ? DateTime.Today : startDate;
                finishDate = finishDate == null ? DateTime.MaxValue : finishDate;
                
                var orders = ctx.Orders.Include(x => x.Car).Include(c => c.Category).Include(x => x.Client).Where(x => x.Date >= startDate && x.Date <= finishDate).ToList();
                return orders;
            }
        }

        public void AsignCar(int orderId, int carId)
        
        {
            using(var ctx=new TaxiDbContext())
            {
                var order = ctx.Orders.Include(x => x.Car).Where(x=>x.Id==orderId).FirstOrDefault();                
                order.CarId = carId;
                //ctx.Orders.Attach(order);
                //ctx.Entry(order).State = EntityState.Modified;
                //ctx.Entry(order).Property(a => a.CarId).IsModified = true;
               
                ctx.SaveChanges();
            }
        }

      
        //public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>expression)
        //{

        //}
    }
}
