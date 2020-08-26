using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IClientService
    {
       // List<CarCategoryModel> GetAllCategory();
        string CreateOrder(OrderModel order, string id);
        List<OrderModel> GetAllClientOrders(string clientId);
        void EditClientProfile(UserModel client);
        List<UserModel> GetAllClients();
        void DeleteClient(string id);
        //UserModel GetClientById(string Id);
        //CarCategoryModel GetCategoryById(int? id);
        //CarModel GetCarById(int? id);

    }
}
