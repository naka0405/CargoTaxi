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
        private readonly IClientRepository _clientRepozitoriy;        
        public readonly IMapper _mapper;
       
        public ClientService(IClientRepository clientRepozitoriy, IMapper mapper )
        {
            _clientRepozitoriy = clientRepozitoriy;
            _mapper = mapper;            
        }
        public UserModel GetClientById(string id)
        {
            var clientInBd = _clientRepozitoriy.GetClientById(id);
            var clientBL = _mapper.Map<UserModel>(clientInBd);
            return clientBL;
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
