using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class CarCategoryService : ICarCategoryService
    {
        private readonly ICarCategoryRepository _carCategoryRepozitoriy;
        public readonly IMapper _mapper;

        public CarCategoryService(ICarCategoryRepository carCategoryRepozitoriy, IMapper mapper)
        {
            _carCategoryRepozitoriy = carCategoryRepozitoriy;
            _mapper = mapper;

        }
        public List<CarCategoryModel> GetAllCarCategories()
        {
            var allCarCategories = _carCategoryRepozitoriy.GetAllCategories();
            var allCarCategoriesBL = _mapper.Map<List<CarCategoryModel>>(allCarCategories);
            return allCarCategoriesBL;
        }

        public CarCategoryModel GetCarCategoryById(int? id)
        {
            var carCategory = _carCategoryRepozitoriy.GetCarCategoryById(id);
            var carCategoryBl = _mapper.Map<CarCategoryModel>(carCategory);
            return carCategoryBl;
        }
    }
}
