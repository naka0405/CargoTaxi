using AutoMapper;
using Business.Interfaces;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;   
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper, IOrderService orderService)
        {
           
            _mapper = mapper;
            _orderService = orderService;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
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
    }
}