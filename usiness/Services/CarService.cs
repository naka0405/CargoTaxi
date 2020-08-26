using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepozitory _carRepozitoriy;       
        public readonly IMapper _mapper;
       
        public CarService(ICarRepozitory carRepozitoriy, IMapper mapper)
        {
            _carRepozitoriy = carRepozitoriy;        
            _mapper = mapper;
           
        }
        public void CreateCar(CarModel carModel)
        {
            var car = _mapper.Map<Car>(carModel);
            _carRepozitoriy.CreateCar(car);
        }

        public void DeleteCar(int id)
        {
            _carRepozitoriy.DeleteCar(id);
        }

        public void EditCar(CarModel carModel)
        {
            var car = _mapper.Map<Car>(carModel);
            _carRepozitoriy.EditCar(car);
        }

        public List<CarModel> GetAllCars()
        {
            var cars = _carRepozitoriy.GetAllCars();
            var carModels = _mapper.Map<List<CarModel>>(cars);
            return carModels;
        }

        public CarModel GetCarById(int id)
        {
            var carInBd = _carRepozitoriy.GetCarById(id);
            var carModel = _mapper.Map<CarModel>(carInBd);
            return carModel;
        }
    }
}
