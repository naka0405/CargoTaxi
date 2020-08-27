using AutoMapper;
using Business.Interfaces;
using Business.Services;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    public class CarCategoryController : Controller
    {
        private readonly ICarCategoryService _carCategoryService;
        

        private readonly IMapper _mapper;
        public CarCategoryController(IMapper mapper, ICarCategoryService carCategoryService)
        {
           
            _mapper = mapper;
            _carCategoryService = carCategoryService;
        }

        public ActionResult AllCarCatigories()
        {
            var carCategoryModels = _carCategoryService.GetAllCarCategories();
            var carCategoryViewModels = _mapper.Map<List<CarCategoryViewModel>>(carCategoryModels);
            return View(carCategoryViewModels);
        }

        public ActionResult CarCategoryDetails(int id)
        {
            var carCategoryModel = _carCategoryService.GetCarCategoryById(id);
            var carCategoryViewModel = _mapper.Map<CarCategoryViewModel>(carCategoryModel);
            return View(carCategoryViewModel);
        }
    }
}