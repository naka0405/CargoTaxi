using CargoTaxi.Data.Models;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IDriverRepozitoriy
    {
        //        план на неделю
        //просмотреть свои заказы
        //просмотреть свои выполненные заказы
        List<Order> GetOrdersForNextWeek(string id);
        List<Order> GetMyOrders(string id, DateTime? startDate, DateTime? finishDate);
        List<Order> GetMyDoneOrders(string id);
        List<Order> GetTodayOrders(string id);
        List<Order> GetNotDoneOrders(string id);
        List<Order> GetLastOrders(string id);
        void ChangeOrderStatus(OrderPropForUpdate order);
        // void CreateDriverAsync(ApplicationUser driver );
        void CreateDriver(ApplicationUser driver);
        void UpdateDriver(ApplicationUser driver);
        void DeactivateDriver(string id);
        List<ApplicationUser> GetAllDrivers();
        ApplicationUser GetDriverById(string id);
        ApplicationUser GetDriverByEmail(string email);
    }
}
