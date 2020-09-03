using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        string CreateOrder(OrderModel order, string id);        
        List<OrderModel> GetAllOrders();
        List<OrderModel> GetNotDoneOrders();
        void EditOrder(OrderModel order);
        void DeleteOrder(int id);
        OrderModel GetOrderById(int id);
        List<OrderModel> GetOrderByCarRegistrNumber(string number);
        List<OrderModel> GetOrderByClientTel(string tel);
        List<OrderModel> GetTodayOrders();
        List<OrderModel> GetNotAsignOrders();
        List<OrderModel> OrdersByDate(DateTime? startDate, DateTime? finishDate);
        void AsignCar(int orderId, int carId);

    }
}
