using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IClientHelperService _helperService;
        private readonly IDriverService _driverService;

        private readonly IMapper _mapper;
        public CarController(IMapper mapper, ICarService carService, IClientHelperService helper, IDriverService driverService)
        {
            _driverService = driverService;
            _helperService = helper;
            _mapper = mapper;
          _carService = carService;
        }


        // GET: Car
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult AllCars()
        {
            var carModels=_carService.GetAllCars();
            var carsViewModel = _mapper.Map<List<CarViewModel>>(carModels);
            return View(carsViewModel);
        }

        public ActionResult CreateCar()
        {
            SelectList carCategories = new SelectList(_helperService.GetAllCategory(), "Id", "Name");
            ViewBag.Categories = carCategories;

            var driverViewModels = _driverService.GetAllDrivers().Select(x => new DriverViewModel
            {
                Id=x.Id,
                Name = x.FirstName + " " + x.LastName
            }
            );
            SelectList drivers = new SelectList(driverViewModels, "Id", "Name" );
            ViewBag.Drivers = drivers;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(CarPostViewModel model)
        {
            var carModel = _mapper.Map<CarModel>(model);
            _carService.CreateCar(carModel);
            return RedirectToAction("Index","Admin");

        }
        public ActionResult Delete(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction("AllCars");
        }

        public ActionResult EditCar(int id)
        {
            var car = _carService.GetCarById(id);
            var carVM = _mapper.Map<CarViewModel>(car);
            SelectList carCategories = new SelectList(_helperService.GetAllCategory(), "Id", "Name");
            ViewBag.Categories = carCategories;

            var driverViewModels = _driverService.GetAllDrivers().Select(x => new DriverViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            }
            );
            SelectList drivers = new SelectList(driverViewModels, "Id", "Name");
            ViewBag.Drivers = drivers;
            return View(carVM);
        }

        [HttpPost]
        public ActionResult EditCar(CarPostViewModel car)
        {
            var carModel = _mapper.Map<CarModel>(car);
            _carService.EditCar(carModel);
            return RedirectToAction("AllCars");
            
        }
         public ActionResult CarDetails(int id)
        {
            var carModel=_carService.GetCarById(id);
            var carViewModel = _mapper.Map<CarViewModel>(carModel);
            return View(carViewModel);
        }

        
    }
}