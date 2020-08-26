using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IOrderRepozitoriy
    {
        //        Все заказы
        //Добавить заказ
        //редактировать заказ
        //удалить заказ
        //получить заказ по Id
        //получить заказ по номеру тел
        //получить заказ по номеру машины
        //void CreateOrder(Order order);
        List<Order> GetAllOrders();
        List<Order> GetNotDoneOrders();
        void EditOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrderById(int id);
        Order GetOrderByCarRegistrNumber(string number);
        Order GetOrderByDriverTel(string tel);
    }
}
