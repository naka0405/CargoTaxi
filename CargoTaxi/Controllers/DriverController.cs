using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    [Authorize(Roles = "Driver,Admin")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        
        private readonly IMapper _mapper;
        public DriverController( IMapper mapper, IDriverService driverService)
        {
            _mapper = mapper;
            _driverService = driverService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMyOrders()
        {
            return View("SetDates");
        }


        [HttpPost]
        public ActionResult GetMyOrders(DateTime? startDate, DateTime? finishDate)
        {
            var id = User.Identity.GetUserId();
            var listDriverOrders = new List<DriverOrderViewModel>();
            var driverOrders = _driverService.GetMyOrders(id, startDate, finishDate);
            if(driverOrders!=null)
            {
              listDriverOrders = MapForView(driverOrders);
            }
            ViewBag.Message = "Заказы за указанный период";
            return View(listDriverOrders); ;
        }

        public ActionResult GetMyDoneOrders()
        {
            var id = User.Identity.GetUserId();
            var ordersForView = new List<DriverOrderViewModel>();
            var todayOrders = _driverService.GetMyDoneOrders(id);
            if(todayOrders!=null)
            {
              ordersForView = MapForView(todayOrders);
            }
            
            ViewBag.Message = "Выполненные заказы";
            return View("GetMyOrders", ordersForView);
        }
        public ActionResult GetTodayOrders()
        {
            var id = User.Identity.GetUserId();
            var ordersForView= new List<DriverOrderViewModel>();
            var todayOrders = _driverService.GetTodayOrders(id);
            if(todayOrders!=null)
            {
              ordersForView = MapForView(todayOrders);
            }
           
            ViewBag.Message = "Заказы на сегодня";
            return View("GetMyOrders",ordersForView);            
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

        public ActionResult CheckOrder()
        {
            string id = User.Identity.GetUserId();
            var todayOrders = _driverService.GetNotDoneOrders(id);
           
            List<DriverOrderViewModel> ordersForView = new List<DriverOrderViewModel>();
            if (todayOrders != null)
            {
                ordersForView = MapForView(todayOrders);              
            }
            return View("CheckOrder", ordersForView);
        }
        [HttpPost]
        public ActionResult CheckOrder(List<OrderPostModel>models)
        {           
            if(models!=null)
            {
                foreach(var model in models)
                {
                    var modelBl = _mapper.Map<OrderModelForUpdate>(model);                   
                    _driverService.UpdateOrder(modelBl);
                }               
            }
            return RedirectToAction("Index");
        }

        public List<DriverOrderViewModel> MapForView(List<OrderModel> model)
        {
            var models=model.Select(x=>new DriverOrderViewModel()
            {
                Id=x.Id,
                Number = x.Number,
                Date = x.Date.ToShortDateString(),
                StartAdress = x.StartAdress,
                FinishAdress = x.FinishAdress,
                StartTime = x.StartTime,
                FinishTime = x.FinishTime,
                CarCategory = x.Car.Category.Name.ToString(),
                Car = x.Car.RegistrNumber,
                IsDone=x.IsDone,
                ClientPhone = x.Client.PhoneNumber
            });
            var modelsForView = models.Cast<DriverOrderViewModel>().ToList();
            return modelsForView;
        }

        public ActionResult GetOrdersForNextWeek()
        {
            var id = User.Identity.GetUserId();
            var driverOrdersBl = new List<OrderModel>();
            var listDriverOrders = new List<DriverOrderViewModel>();
            var driverOrders = _driverService.GetOrdersForNextWeek(id);
            if(driverOrders!=null)
            {
                driverOrdersBl = _mapper.Map<List<OrderModel>>(driverOrders);
                listDriverOrders = MapForView(driverOrdersBl);
            }
            ViewBag.Message = "Заказы на следующую неделю";
            return View("GetMyOrders", listDriverOrders); ;
        }
        public ActionResult GetPartialView()
        {
            var id = User.Identity.GetUserId();
            var ordersForView= new List<DriverOrderViewModel>();
            var lastOrders = _driverService.GetLastOrders(id);
            if(lastOrders!=null)
            {
                ordersForView = MapForView(lastOrders);
            }
            return PartialView("PartialView",ordersForView);
        }

        public ActionResult DeactivateDriver(string id)
        {
            _driverService.DeactivateDriver(id);
            return View("Drivers");
        }

        public ActionResult Edit(string id)
        {
            var driverModel = _driverService.GetDriverById(id);
            var driver = _mapper.Map<UserViewModel>(driverModel);
            return View(driver);
        }

        [HttpPost]
        public ActionResult Edit(DriverPostViewModel model)
        {
           var userModel = _mapper.Map<UserModel>(model);
            _driverService.UpdateDriver(userModel);
            return RedirectToAction("GetAllDrivers");
        }

        public ActionResult GetAllDrivers()
        {
            var driverModels = _driverService.GetAllDrivers();
            var drivers = _mapper.Map<List<UserViewModel>>(driverModels);
            return View("Drivers",drivers);
        }

        public ActionResult CreateDriver(UserViewModel user)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDriver(DriverPostViewModel model)
        {
            var driverModel = _mapper.Map<UserModel>(model);
            _driverService.CreateDriver(driverModel);
            return RedirectToAction("GetAllDrivers");
        }

        public ActionResult DriverDetails(string id)
        {
            var userModel = _driverService.GetDriverById(id);
            var userViewModel = _mapper.Map<UserViewModel>(userModel);
            return View(userViewModel);
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
