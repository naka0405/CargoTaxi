using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Data.Repozitories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepozitoriy _clientRepozitoriy;
        private readonly IClientHelper _helperRepozitoriy;
        public readonly IMapper _mapper;
        private StringBuilder _stringBuilder;
        public ClientService(IClientRepozitoriy clientRepozitoriy, IMapper mapper, IClientHelper helper)
        {
            _helperRepozitoriy = helper;
            _clientRepozitoriy = clientRepozitoriy;
            _mapper = mapper;
            _stringBuilder = new StringBuilder();
        }
        public string CreateOrder(OrderModel orderBL, string id)
        {
            var order = _mapper.Map<Order>(orderBL);
            var orderNumber = CreateOrderNumber();
            order.Number = orderNumber;
            _clientRepozitoriy.CreateOrder(order, id);
            return orderNumber;
        }
        private string CreateOrderNumber()
        {
            var randomNumb = new Random().Next(1,300);
            _stringBuilder.Append(DateTime.Today.ToShortDateString());
            _stringBuilder.AppendFormat($"/{randomNumb}");
            var strNumber = _stringBuilder.ToString();
            return strNumber;
        }
        public List<OrderModel> GetAllClientOrders(string clientId)
        {
            var allOrders = _clientRepozitoriy.GetMyAllOrders(clientId);
            
            //var allOrdersBl = allOrders.Select(x => new OrderModel()
            //{
            //    Id=x.Id,
            //    Date = x.Date,
            //    Number = x.Number,
            //    StartAdress = x.StartAdress,
            //    FinishAdress = x.FinishAdress,
            //    StartTime = x.StartTime,
            //    FinishTime = x.FinishTime,
            //    CarCategoryId = x.CarCategoryId,

            //    ClientId = x.ClientId
            //});
            //var allOrdersBL = new List<OrderModel>(allOrdersBl);
            var allOrdersBL = _mapper.Map<List<OrderModel>>(allOrders);
            return allOrdersBL;
        }

        public void EditClientProfile(UserModel clientBl)
        {
            var clientInBd = _mapper.Map<ApplicationUser>(clientBl);
            _clientRepozitoriy.EditClientProfile(clientInBd);
        }

        public List<UserModel> GetAllClients()
        {
            var clientsInDb = _clientRepozitoriy.GetAllClients();
            var clientModel = _mapper.Map<List<UserModel>>(clientsInDb);
            return clientModel;
        }

        public void DeleteClient(string id)
        {
            _clientRepozitoriy.DeleteClient(id);
        }
    }
}
