using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly ICarService _carService;
        private readonly IDriverService _driverService;
        private readonly ICarCategoryService _carCategoryService;

        private readonly IMapper _mapper;
        public AdminController(IMapper mapper, IClientService clientService, ICarService carService, IOrderService orderService, IDriverService driverService, ICarCategoryService carCategoryService)
        {
            _clientService = clientService;
            _carCategoryService = carCategoryService;
            _carService = carService;
            _driverService = driverService;
            _mapper = mapper;
            _orderService = orderService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult AsignCar()
        //{
        //    var orderModels = _orderService.GetNotDoneOrders();
        //    var orderVM = _mapper.Map<List<OrderViewModel>>(orderModels);
        //    return View(orderVM);
        //}
        public ActionResult FindView(int? findParam, string mes = null)
        {
            FindParamViewModel model = new FindParamViewModel();
            //< form method = "post" action = "/Home/Buy" >
            switch (findParam)
            {
                case 1:
                    model.Action = "FindEmail";
                    model.Title = "Поиск по Email";
                    model.ParamName = "Email";
                    break;
                case 2:
                    model.Action = "../Order/FindOrderByPhoneNumber";
                    model.Title = "Поиск по номеру телефона клиента";
                    model.ParamName = "Номер телефона в формате 1111111111";
                    break;
                case 3:

                    model.Action = "../Order/FindOrderByCarNumber";
                    model.ParamName = "Номер машины";
                    if (mes == null)
                    {
                        model.Title = "Поиск по номеру машины";
                    }
                    else
                    { 
                    model.Title = "Авто с номером  " + mes + "не зарегистрировано, введите правильный номер машины";}
                    break;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult FindEmail(string param)
        {
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            if (!Regex.IsMatch(param, pattern))
            {
                return RedirectToAction("FindView", new { findParam = 1 });
            }
            var userModel = _driverService.GetDriverByEmail(param);
            if (userModel != null)
            {
                var user = _mapper.Map<UserViewModel>(userModel);

                return RedirectToAction("CreateDriver", "Admin", user);
            }
            else
            {
                var id = User.Identity.GetUserId();
                return RedirectToAction("Register", "Account", new { Id = id });
            }

        }

        public ActionResult AllNotAsignOrders()
        {
            var orderModels = _orderService.GetNotAsignOrders();
            var orders = _mapper.Map<List<OrderViewModel>>(orderModels);
            orders = orders.Where(x => x.Date >= System.DateTime.Today).ToList();            
            return View(orders);
        }


        //[HttpPost]
        public ActionResult GetCarsForAsign(int id)
        {
            var order = _orderService.GetOrderById(id);

            var carModels = _carService.GetCarsForAsign(order.Date, order.PartOfDay, order.CarCategoryId);
            var cars = _mapper.Map<List<CarViewModel>>(carModels);
            var model = new CarsForOrderViewModel
            {
                Cars = cars,
                OrderId = order.Id,
                OrderNumber = order.Number,
                OrderDate = order.Date,
                StartTime = order.StartTime
            };

            return View(model);
        }
        public ActionResult EditOrder(int orderId, int carId)
        {
            _orderService.AsignCar(orderId, carId);
            return RedirectToAction("AllNotAsignOrders", "Admin");//, new { id = orderId });
        }

        public ActionResult ChangeOrder(int id)
        {
            var orderModel = _orderService.GetOrderById(id);
            SelectList carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
            SelectList carRegisterNumberes = new SelectList(_carService.GetAllCars(), "Id", "RegistrNumber");
            var orderVM = _mapper.Map<ChangeOrderViewModel>(orderModel);
            orderVM.CarRegisterNumbers = carRegisterNumberes;
            orderVM.Categories = carCategories;
            return View("ChangeOrder", orderVM);
        }

        [HttpPost]
        public ActionResult ChangeOrder(EditOrderPostModel orderPM)
        {
            SelectList carCategories;
            if (ModelState.IsValid)
            {
                //carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
                //orderPM.Categories = carCategories;
                var orderBl = _mapper.Map<OrderModel>(orderPM);
                _orderService.EditOrder(orderBl);
                return RedirectToAction("NotDoneOrders", "Order");
            }
            var orderModel = _orderService.GetOrderById(orderPM.Id);
            carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
            var orderVM = _mapper.Map<ChangeOrderViewModel>(orderModel);
            orderVM.Categories = carCategories;
            return View("ChangeOrder", orderVM);
        }


        public ActionResult AllClients()
        {
            var clientsModel = _clientService.GetAllClients();
            var clientsVM = _mapper.Map<List<UserViewModel>>(clientsModel);
            return View(clientsVM);
        }


        public ActionResult DeleteClient(string id)
        {
            _clientService.DeleteClient(id);
            return RedirectToAction("AllClients");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeactivateDriver(string id)
        {
            _driverService.DeactivateDriver(id);
            return RedirectToAction("GetAllDrivers", "Admin");
        }


        public ActionResult Edit(string id)
        {
            var driverModel = _driverService.GetDriverById(id);
            var driver = _mapper.Map<UserViewModel>(driverModel);
            return View(driver);
        }


        [HttpPost]
        public ActionResult Edit(DriverPostModel model)
        {
            var userModel = _mapper.Map<UserModel>(model);
            _driverService.UpdateDriver(userModel);
            return RedirectToAction("GetAllDrivers");
        }


        public ActionResult GetAllDrivers()
        {
            var driverModels = _driverService.GetAllDrivers();
            var drivers = _mapper.Map<List<UserViewModel>>(driverModels);
            return View("Drivers", drivers);
        }


        //public ActionResult CreateDriver(UserViewModel user)
        //{
        //    user.ViewMessage = "Такой водитель уже зарегистрирован";
        //    return View(user);
        //}


        //[HttpPost]
        public ActionResult CreateDriver(DriverPostModel model)
        {
            var driverModel = _mapper.Map<UserModel>(model);
            _driverService.CreateDriver(driverModel);
            return RedirectToAction("GetAllDrivers");
        }


        public ActionResult DriverDetails(string id)
        {
            var userModel = _driverService.GetDriverById(id);
            var userViewModel = _mapper.Map<UserViewModel>(userModel);
            return View("../Driver/DriverDetails", userViewModel);
        }

    }
}