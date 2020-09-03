using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        private readonly IMapper _mapper;
        public DriverController(IMapper mapper, IDriverService driverService)
        {
            _mapper = mapper;
            _driverService = driverService;
        }

        [Authorize(Roles = "Driver")]
        public ActionResult Index()
        {

            return View();
        }

        [Authorize(Roles = "Driver,Admin")]
        public ActionResult GetMyOrders()
        {
            return View("SetDates");
        }

        [Authorize(Roles = "Driver")]
        [HttpPost]
        public ActionResult GetMyOrders(DateTime? startDate, DateTime? finishDate)
        {
            var id = User.Identity.GetUserId();
            var listDriverOrders = new List<DriverOrderViewModel>();
            var driverOrders = _driverService.GetMyOrders(id, startDate, finishDate);
            if (driverOrders != null)
            {
                listDriverOrders = _mapper.Map<List<DriverOrderViewModel>>(driverOrders);
            }
            var modelForView = new ListDriverOrdersViewModel() { OrdersList = listDriverOrders, MessageForView = "Заказы за указанный период" };
            return View(modelForView);
        }


        [Authorize(Roles = "Driver")]
        public ActionResult GetMyDoneOrders()
        {
            var id = User.Identity.GetUserId();
            var ordersForView = new List<DriverOrderViewModel>();
            var doneOrders = _driverService.GetMyDoneOrders(id);
            if (doneOrders != null)
            {
                ordersForView = _mapper.Map<List<DriverOrderViewModel>>(doneOrders);
            }
            var modelForView = new ListDriverOrdersViewModel() { OrdersList = ordersForView, MessageForView = "Выполненные заказы" };               
            return View("GetMyOrders", modelForView);
        }


        [Authorize(Roles = "Driver")]
        public ActionResult Rules()
        {
            return View();
        }


            [Authorize(Roles = "Driver")]
        public ActionResult GetTodayOrders()
        {
            var id = User.Identity.GetUserId();
            var ordersForView = new List<DriverOrderViewModel>();
            var todayOrders = _driverService.GetTodayOrders(id);
            if (todayOrders != null)
            {
                ordersForView = _mapper.Map<List<DriverOrderViewModel>>(todayOrders);
            }
            var modelForView = new ListDriverOrdersViewModel() { OrdersList = ordersForView, MessageForView = "Заказы на сегодня" };
            modelForView.MessageForView = "Заказы на "+DateTime.Today.ToShortDateString();
            return View("GetMyOrders", modelForView);
        }

        //public ActionResult CheckOrder()
        //{
        //    string id = User.Identity.GetUserId();
        //    var todayOrders = _driverService.GetNotDoneOrders(id);
        //    IEnumerable<DriverOrderViewModel> ordersForView = new List<DriverOrderViewModel>();
        //    if(todayOrders!=null)
        //    {
        //         ordersForView = MapForView(todayOrders);
        //        //var orderList = new List<DriverOrderViewModel>(ordersForView);
        //    }
        //    return View(ordersForView);
        //}


        [Authorize(Roles = "Driver")]
        public ActionResult CheckOrder()
        {
            string id = User.Identity.GetUserId();
            var todayOrders = _driverService.GetNotDoneOrders(id);

            List<DriverOrderViewModel> ordersForView = new List<DriverOrderViewModel>();
            if (todayOrders != null)
            {
                ordersForView = _mapper.Map<List<DriverOrderViewModel>>(todayOrders);
            }
            return View("CheckOrder", ordersForView);
        }


        [Authorize(Roles = "Driver")]
        [HttpPost]
        public ActionResult CheckOrder(List<OrderPostModel> models)
        {
            if (models != null)
            {
                foreach (var model in models)
                {
                    var modelBl = _mapper.Map<OrderModelForUpdate>(model);
                    _driverService.UpdateOrder(modelBl);
                }
            }
            return RedirectToAction("Index");
        }

        //private List<DriverOrderViewModel> MapForView(List<OrderModel> model)
        //{
        //    var models = model.Select(x => new DriverOrderViewModel()
        //    {
        //        Id = x.Id,
        //        Number = x.Number,
        //        Date = x.Date.ToShortDateString(),
        //        StartAdress = x.StartAdress,
        //        FinishAdress = x.FinishAdress,
        //        StartTime = x.StartTime,
        //        FinishTime = x.FinishTime,
        //        CarCategory = x.Car.Category.Name.ToString(),
        //        Car = x.Car.RegistrNumber,
        //        IsDone = x.IsDone,
        //        ClientPhone = x.Client.PhoneNumber
        //    });
        //    var modelsForView = models.Cast<DriverOrderViewModel>().ToList();
        //    return modelsForView;
        //}


        [Authorize(Roles = "Driver")]
        public ActionResult GetOrdersForNextWeek()
        {
            var id = User.Identity.GetUserId();
            
            var listDriverOrders = new List<DriverOrderViewModel>();
            var driverOrders = _driverService.GetOrdersForNextWeek(id);
            if (driverOrders != null)
            {
                listDriverOrders = _mapper.Map<List<DriverOrderViewModel>>(driverOrders);
            }
            var modelForView = new ListDriverOrdersViewModel() { OrdersList = listDriverOrders, MessageForView = "Заказы на следующую неделю" };
           
            return View("GetMyOrders", modelForView); ;
        }

        [Authorize(Roles = "Driver")]
        public ActionResult GetPartialView()
        {
            var id = User.Identity.GetUserId();
            var ordersForView = new List<DriverOrderViewModel>();
            var lastOrders = _driverService.GetLastOrders(id);
            if (lastOrders != null)
            {
                ordersForView = _mapper.Map<List<DriverOrderViewModel>>(lastOrders);
            }

            return PartialView("PartialView", ordersForView);
        }

       

        //[HttpPost]
        // public JsonResult GetMyOrders(DateTime? startDate, DateTime? finishDate)
        // {            
        //     var id = User.Identity.GetUserId();
        //     var driverOrders = _driverService.GetMyOrders(id, startDate, finishDate);
        //     var driverOrdersBl = _mapper.Map<List<OrderViewModel>>(driverOrders);
        //     var listDriverOrders = driverOrdersBl.Select(x => new DriverOrderViewModel()
        //     {
        //         Number = x.Number,
        //         Date = x.Date,
        //         StartAdress = x.StartAdress,
        //         FinishAdress = x.FinishAdress,
        //         StartTime = x.StartTime,
        //         FinishTime = x.FinishTime,
        //         CarCategory = x.Car.Category.Name.ToString(),
        //         Car = x.Car.RegistrNumber
        //     });
        //     return Json(new { OrderList = listDriverOrders }, JsonRequestBehavior.AllowGet); ;
        // }

    }
}
