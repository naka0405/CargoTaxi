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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepozitoriy _orderRepozitory;
        private readonly IMapper _mapper;
        public OrderService(IMapper mapper, IOrderRepozitoriy orderRepozitoriy)
        {
            _orderRepozitory = orderRepozitoriy;
            _mapper = mapper;
        }
        public void CreateOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public List<OrderModel> GetAllOrders()
        {
            var orders = _orderRepozitory.GetAllOrders();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public List<OrderModel> GetNotDoneOrders()
        {
            var orders =_orderRepozitory.GetNotDoneOrders();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public OrderModel GetOrderByCarRegistrNumber(string number)
        {
            throw new NotImplementedException();
        }

        public OrderModel GetOrderByDriverTel(string tel)
        {
            throw new NotImplementedException();
        }

        public OrderModel GetOrderById(int id)
        {
            var order = _orderRepozitory.GetOrderById(id);
            var orderModel = _mapper.Map<OrderModel>(order);
            return orderModel;
        }
    }
}
