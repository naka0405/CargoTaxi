using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepozitoriy;
        public readonly IMapper _mapper;
        //private readonly IDriverHelper _driverHelperRepozitoriy;
        // private StringBuilder _stringBuilder;
        public DriverService(IDriverRepository driverRepozitoriy, IMapper mapper)
        {
            //_driverHelperRepozitoriy = helper;
            _driverRepozitoriy = driverRepozitoriy;
            _mapper = mapper;
         
        }
        public UserModel GetDriverById(string id)
        {
            var driver = _driverRepozitoriy.GetDriverById(id);
            var driverBL = _mapper.Map<UserModel>(driver);
            return driverBL;
        }

        public UserModel GetDriverByEmail(string email)
        {
            var driver = _driverRepozitoriy.GetDriverByEmail(email);
            var driverBL = _mapper.Map<UserModel>(driver);
            return driverBL;
        }
        public List<OrderModel> GetMyDoneOrders(string id)
        {
            var orders = _driverRepozitoriy.GetMyDoneOrders(id);
            var ordersBl = _mapper.Map<List<OrderModel>>(orders);
            return ordersBl;
        }

        public List<OrderModel> GetMyOrders(string id, DateTime? startDate, DateTime? finishDate)
        {
           var orders= _driverRepozitoriy.GetMyOrders(id, startDate, finishDate);
            var ordersBl = _mapper.Map <List<OrderModel>>(orders);
            return ordersBl;
        }

        public List<OrderModel> GetOrdersForNextWeek(string id)
        {
            var orders = _driverRepozitoriy.GetOrdersForNextWeek(id);
            var ordersBl = _mapper.Map<List<OrderModel>>(orders);
            return ordersBl;
        }

        public List<OrderModel> GetTodayOrders(string id)
        {
            var orders = _driverRepozitoriy.GetTodayOrders(id);
            var ordersBL = _mapper.Map<List<OrderModel>>(orders);
            return ordersBL;
        }
        public List<OrderModel> GetLastOrders(string id)
        {
            var orders = _driverRepozitoriy.GetLastOrders(id);
            var ordersBL = _mapper.Map<List<OrderModel>>(orders);
            return ordersBL;
        }

        public List<OrderModel> GetNotDoneOrders(string id)
        {
            var orders = _driverRepozitoriy.GetNotDoneOrders(id);
            var ordersBL = _mapper.Map<List<OrderModel>>(orders);
            return ordersBL;
        }

        public void UpdateOrder(OrderModelForUpdate orderModel)
        {
            var order = _mapper.Map<OrderPropForUpdate>(orderModel);
            _driverRepozitoriy.ChangeOrderStatus(order);
        }

        public void CreateDriver(UserModel driver)
        {
            var driverInDb = _mapper.Map<ApplicationUser>(driver);
            _driverRepozitoriy.CreateDriver(driverInDb);
        }

        public void UpdateDriver(UserModel driver)
        {
            var driverInDb = _mapper.Map<ApplicationUser>(driver);
            _driverRepozitoriy.UpdateDriver(driverInDb);
        }

        public void DeactivateDriver(string id)
        {
            _driverRepozitoriy.DeactivateDriver(id);
        }

        public List<UserModel> GetAllDrivers()
        {
            var drivers = _driverRepozitoriy.GetAllDrivers();
            var driverModels = _mapper.Map<List<UserModel>>(drivers);
            return driverModels;
        }
    }
}
