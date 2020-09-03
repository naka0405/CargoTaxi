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
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IDriverService _driverService;
        private readonly ICarCategoryService _carCategoryService;

        private readonly IMapper _mapper;
        public CarController(IMapper mapper, ICarService carService, ICarCategoryService carCategoryService, IDriverService driverService)
        {
            _driverService = driverService;
            _carCategoryService = carCategoryService;
            _mapper = mapper;
            _carService = carService;
        }

        public ActionResult AllCars()
        {
            var carModels = _carService.GetAllCars();
            var carsViewModel = _mapper.Map<List<CarViewModel>>(carModels);
            return View(carsViewModel);
        }

        public ActionResult AllCarsIsLoad()
        {
            var carModels = _carService.GetAllCars();
            carModels = carModels.Where(x => x.IsLoad == true).ToList();
            var carsViewModel = _mapper.Map<List<CarViewModel>>(carModels);
            return View(carsViewModel);
        }

        public ActionResult CreateCar(string message = null)
        {
            var viewModel = new CreateCarViewModel();
            SelectList carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
            viewModel.CarCategories = carCategories;

            var driverViewModels = _driverService.GetAllDrivers().Select(x => new DriverViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            }
            );
            SelectList drivers = new SelectList(driverViewModels, "Id", "Name");
            viewModel.Drivers = drivers;
            viewModel.Message = message;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateCar(CarPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var carModel = _mapper.Map<CarModel>(model);
                if (_carService.GetCarByRegisterNumber(model.RegistrNumber) == null)
                {
                    _carService.CreateCar(carModel);
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("CreateCar", new { message = $"Машина с номером {model.RegistrNumber} уже зарегистрирована" });
            }
            var viewModel = new CreateCarViewModel();
            SelectList carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
            viewModel.CarCategories = carCategories;

            var driverViewModels = _driverService.GetAllDrivers().Select(x => new DriverViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            }
            );
            SelectList drivers = new SelectList(driverViewModels, "Id", "Name");
            viewModel.Drivers = drivers;
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction("AllCars");
        }

        public ActionResult EditCar(int id)
        {
            var car = _carService.GetCarById(id);
            var carVM = _mapper.Map<CreateCarViewModel>(car);
            SelectList carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
            carVM.CarCategories = carCategories;

            var driverViewModels = _driverService.GetAllDrivers().Select(x => new DriverViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            }
            );
            SelectList drivers = new SelectList(driverViewModels, "Id", "Name");
            carVM.Drivers = drivers;
            return View(carVM);
        }

        [HttpPost]
        public ActionResult EditCar(CarPostViewModel car)
        {
            if (ModelState.IsValid)
            {
                var carBl = _mapper.Map<CarModel>(car);
                _carService.EditCar(carBl);
                return RedirectToAction("AllCars");
            }
            var carModel = _carService.GetCarById(car.Id);
            var carVM = _mapper.Map<CreateCarViewModel>(carModel);
            SelectList carCategories = new SelectList(_carCategoryService.GetAllCarCategories(), "Id", "Name");
            carVM.CarCategories = carCategories;

            var driverViewModels = _driverService.GetAllDrivers().Select(x => new DriverViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            }
            );
            SelectList drivers = new SelectList(driverViewModels, "Id", "Name");
            carVM.Drivers = drivers;
            return View("EditCar", carVM);
        }

        public ActionResult CarDetails(int id)
        {
            var carModel = _carService.GetCarById(id);
            var carViewModel = _mapper.Map<CarViewModel>(carModel);
            return View(carViewModel);
        }
    }
}