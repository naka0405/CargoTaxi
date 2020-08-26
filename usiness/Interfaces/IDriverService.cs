using Business.Models;
using System;
using System.Collections.Generic;


namespace Business.Interfaces
{
    public interface IDriverService
    {
        List<OrderModel> GetOrdersForNextWeek(string id);
        List<OrderModel> GetMyOrders(string id, DateTime? startDate, DateTime? finishDate);
        List<OrderModel> GetMyDoneOrders(string id);
        List<OrderModel> GetTodayOrders(string id);
        List<OrderModel> GetNotDoneOrders(string id);
        List<OrderModel> GetLastOrders(string id);
        void UpdateOrder(OrderModelForUpdate orderModel);

        void CreateDriver(UserModel driver);
        void UpdateDriver(UserModel driver);
        void DeactivateDriver(string id);
        List<UserModel> GetAllDrivers();
        UserModel GetDriverById(string id);
        UserModel GetDriverByEmail(string email);
    }
}
