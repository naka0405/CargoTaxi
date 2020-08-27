
using AutoMapper;
using Business.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOrderService _orderService;
        //private readonly ICarService _carService;
        private readonly IDriverService _driverService;

        private readonly IMapper _mapper;
        public AdminController(IMapper mapper, IOrderService orderService, IDriverService driverService)
        {
            _driverService = driverService;
            _mapper = mapper;
            _orderService = orderService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AsignCar()
        {
            var orderModels = _orderService.GetNotDoneOrders();
            var orderVM = _mapper.Map<List<OrderViewModel>>(orderModels);
            return View(orderVM);
        }
        public ActionResult FindEmail()
        {

            return View();
        }


        [HttpPost]
        public ActionResult FindEmail(string email)
        {

            var userModel=_driverService.GetDriverByEmail(email);
            if (userModel != null)
            {
                var user = _mapper.Map<UserViewModel>(userModel);
                return RedirectToAction("CreateDriver", "Driver", user);
            }
            else
                return RedirectToAction("Register", "Account");
        }

        public ActionResult NotAsignOrders()
        {
            var notAsignOrderModels = _driverService

        }
    }
}