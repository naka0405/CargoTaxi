using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepozitory;
        private readonly IMapper _mapper;
        private StringBuilder _stringBuilder;
        public OrderService(IMapper mapper, IOrderRepository orderRepozitoriy)
        {
            _orderRepozitory = orderRepozitoriy;
            _mapper = mapper;
            _stringBuilder = new StringBuilder();
        }

        public List<OrderModel> OrdersByDate(DateTime? startDate, DateTime? finishDate)
        {
            var orders = _orderRepozitory.OrdersByDate(startDate,finishDate);
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }
        public void DeleteOrder(int id)
        {
            _orderRepozitory.DeleteOrder(id);
        }

        public void EditOrder(OrderModel orderBL)
        {
            var order = _mapper.Map<Order>(orderBL);
            _orderRepozitory.EditOrder(order);
        }

        public List<OrderModel> GetAllOrders()
        {
            var orders = _orderRepozitory.GetAllOrders();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public List<OrderModel> GetNotAsignOrders()
        {
            var orders = _orderRepozitory.GetNotAssignOrders();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public List<OrderModel> GetNotDoneOrders()
        {
            var orders =_orderRepozitory.GetNotDoneOrders();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public List<OrderModel> GetOrderByCarRegistrNumber(string number)
        {
            var orders = _orderRepozitory.GetOrderByCarRegistrNumber(number);
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public string CreateOrder(OrderModel orderBL, string id)
        {
            var order = _mapper.Map<Order>(orderBL);
            order.StartTime = GetTime(orderBL.StartTime);
            var orderNumber = CreateOrderNumber();
            order.Number = orderNumber;
            order.PartOfDay = GetPart(order.StartTime);
            _orderRepozitory.CreateOrder(order, id);            
            return orderNumber;
        }

        private EnumDayParts GetPart(string startTime)
        {
            var hour = Int32.Parse(startTime.Remove(2, 3));
            var min = Int32.Parse(startTime.Remove(0, 3));
            hour = min > 30 ? hour + 1 : hour;
            if (hour < 12)
                return EnumDayParts.Утро;
            else if (hour >= 12 && hour < 17)
                return EnumDayParts.День;
            else
                return EnumDayParts.Вечер;
        }

        private string GetTime(string time)
        {
            if (!DateTime.TryParse(time, out DateTime newTime))
            {
                var validTime = time.Remove(2, 1);
                var sign = time.Substring(2).Take(1).FirstOrDefault().ToString();
                var hourStr = time.Substring(0, 2);
                var minStr = time.Substring(3);
                time = hourStr + ":" + minStr;
                // newTime = DateTime.Parse(time);
                return time;
            }
            return time;
        }

        private string CreateOrderNumber()
        {
            var randomNumb = new Random().Next(1, 300);
            _stringBuilder.Append(DateTime.Today.ToShortDateString());
            _stringBuilder.AppendFormat($"/{randomNumb}");
            var strNumber = _stringBuilder.ToString();
            return strNumber;
        }

        public List<OrderModel> GetOrderByClientTel(string tel)
        {
            var orders = _orderRepozitory.GetOrderByClientTel(tel);
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public OrderModel GetOrderById(int id)
        {
            var order = _orderRepozitory.GetOrderById(id);
            var orderModel = _mapper.Map<OrderModel>(order);
            return orderModel;
        }
        public List<OrderModel> GetTodayOrders()
        {
            var orders = _orderRepozitory.GetTodayOrders();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public void AsignCar(int orderId, int carId)
        {
            _orderRepozitory.AsignCar(orderId, carId);
        }





        //public OrderModel GetTodayOrders()
        //{
        //    var orders = _orderRepozitory.Get;
        //    var orderModels = _mapper.Map<List<OrderModel>>(orders);
        //    return orderModels;
        //}



    }
}
