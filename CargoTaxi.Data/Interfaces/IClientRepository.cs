using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IClientRepository
    {
        ApplicationUser GetClientById(string Id);
        List<Order> GetMyAllOrders(string id);
        void EditClientProfile(ApplicationUser client);
        List<ApplicationUser> GetAllClients();
        void DeleteClient(string id);

    }
}
