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
        void CreateOrder(OrderModel order);
        List<OrderModel> GetAllOrders();
        List<OrderModel> GetNotDoneOrders();
        void EditOrder(OrderModel order);
        void DeleteOrder(int id);
        OrderModel GetOrderById(int id);
        OrderModel GetOrderByCarRegistrNumber(string number);
        OrderModel GetOrderByDriverTel(string tel);
    }
}
