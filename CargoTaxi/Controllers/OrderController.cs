using AutoMapper;
using Business.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper, ICarService carService, IOrderService orderService)
        {
            _carService = carService;
            _mapper = mapper;
            _orderService = orderService;
        }
              public ActionResult OrderDetails(int id)
        {
            var orderModel = _orderService.GetOrderById(id);
            var orderViewModel = _mapper.Map<OrderViewModel>(orderModel);
            return View(orderViewModel);
        }
       
        public ActionResult Orders()
        {
            var orderModels = _orderService.GetAllOrders();
            var orderVM = _mapper.Map<List<OrderViewModel>>(orderModels);
            return View(orderVM);
        }

       
        [HttpPost]
        public ActionResult FindOrderByPhoneNumber(string param)
        {
            string pattern = @"\d{10}";
            if (!Regex.IsMatch(param, pattern))
            {
                return RedirectToAction("FindView", new { findParam = 1 });                
            }
            ViewBag.Message = "по номеру телефона клиента:" +" "+ param.ToString();
            var ordersBL = _orderService.GetOrderByClientTel(param);
            var orders = _mapper.Map<List<OrderViewModel>>(ordersBL);
            if (orders == null)
            {
                ViewBag.Message = "по номеру телефона клиента:" + " " + param + " не найдены";
            }

            return View("Orders", orders);
        }

        
        [HttpPost]
        public ActionResult FindOrderByCarNumber(string param)
        {
            if(_carService.GetCarByRegisterNumber(param)==null)
            {
                return RedirectToAction("FindView", "Admin", new { findParam = 3, mes=param });
            }
            ViewBag.Message = "по регистрационному номеру машины:" + " " + param;
            var ordersBL = _orderService.GetOrderByCarRegistrNumber(param);
            var orders = _mapper.Map<List<OrderViewModel>>(ordersBL);
            if(orders==null)
            {
                ViewBag.Message = "по регистрационному номеру машины:" + " " + param+" не найдены";
            }
            return View("Orders", orders);
        }

       
        [HttpPost]
         public ActionResult OrdersByDate(DateTime? startDate, DateTime? finishDate)
        {
            var orderModels=_orderService.OrdersByDate(startDate, finishDate);
            var orders = _mapper.Map<List<OrderViewModel>>(orderModels);
            ViewBag.Message = $"за период c {DateTime.Today.ToShortDateString()}:";
            return View("Orders", orders);
        }
       

        
        public ActionResult TodayOrders()
        {
            ViewBag.Message = "на" + " " + DateTime.Today.ToShortDateString();
            var ordersBL = _orderService.GetTodayOrders();
            var orders = _mapper.Map<List<OrderViewModel>>(ordersBL);
            return View("Orders", orders);
        }

       
        public ActionResult NotAsignOrders()
        {
            ViewBag.Message = "назначить машину";
            var ordersBL = _orderService.GetNotAsignOrders();
            var orders = _mapper.Map<List<OrderViewModel>>(ordersBL);
            return View("Orders", orders);
        }

       
        public ActionResult NotDoneOrders()
        {
            ViewBag.Message = "не отмеченные водителем как выполненные";
            var ordersBL = _orderService.GetNotDoneOrders();
            var orders = _mapper.Map<List<OrderViewModel>>(ordersBL);
            return View("Orders", orders);
        }
    }
}