using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Repozitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClientHelperService : IClientHelperService
    {
        private readonly IClientHelper _clientHelperRepozitoriy;
        IMapper _mapper;
        public ClientHelperService(IClientHelper helper, IMapper mapper)
        {
            _mapper = mapper;
            _clientHelperRepozitoriy = helper;
        }

        public List<CarCategoryModel> GetAllCategory()
        {
            var allCarCategories = _clientHelperRepozitoriy.GetAllCategory();
            var allCarCategoriesBL = _mapper.Map<List<CarCategoryModel>>(allCarCategories);
            return allCarCategoriesBL;
        }

        public UserModel GetClientById(string id)
        {
            var clientInBd = _clientHelperRepozitoriy.GetClientById(id);
            var clientBL = _mapper.Map<UserModel>(clientInBd);
            return clientBL;
        }

        public CarModel GetCarById(int? id)
        {
            var car = _clientHelperRepozitoriy.GetCarById(id);
            var carBl = _mapper.Map<CarModel>(car);
            return carBl;
        }

        public CarCategoryModel GetCarCategoryById(int? id)
        {
            var carCategory = _clientHelperRepozitoriy.GetCarCategoryById(id);
            var carCategoryBl = _mapper.Map<CarCategoryModel>(carCategory);
            return carCategoryBl;
        }

    }
}
