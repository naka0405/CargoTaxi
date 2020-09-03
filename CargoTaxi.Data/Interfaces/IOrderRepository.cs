using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IOrderRepository
    {
        //        Все заказы
        //Добавить заказ
        //редактировать заказ
        //удалить заказ
        //получить заказ по Id
        //получить заказ по номеру тел
        //получить заказ по номеру машины
        //void CreateOrder(Order order);
        void CreateOrder(Order order, string id);
        List<Order> GetAllOrders();
        List<Order> GetNotDoneOrders();
        void EditOrder(Order order);
        void UpdateOrderByDriver(Order order);
        List<Order> OrdersByDate(DateTime? startDate, DateTime? finishDate);
        void DeleteOrder(int id);
        Order GetOrderById(int id);
        List<Order> GetOrderByCarRegistrNumber(string number);
        List<Order> GetOrderByClientTel(string tel);
        List<Order> GetTodayOrders();
        List<Order> GetNotAssignOrders();
        void AsignCar(int orderId, int carId);

    }
}
