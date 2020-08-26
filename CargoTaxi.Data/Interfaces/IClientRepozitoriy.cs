using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IClientRepozitoriy
    {       
        void CreateOrder(Order order, string id);//
        List<Order> GetMyAllOrders(string id);
        void EditClientProfile(ApplicationUser client);
        List<ApplicationUser> GetAllClients();
        void DeleteClient(string id);

    }
}
