using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;       
        public readonly IMapper _mapper;
       
        public CarService(ICarRepository carRepozitoriy, IMapper mapper)
        {
            _carRepository = carRepozitoriy;        
            _mapper = mapper;           
        }
        public void CreateCar(CarModel carModel)
        {
            var car = _mapper.Map<Car>(carModel);           
                _carRepository.CreateCar(car);
            
        }

        public void DeleteCar(int id)
        {
            _carRepository.DeleteCar(id);
        }

        public void EditCar(CarModel carModel)
        {                 
                    var car = _mapper.Map<Car>(carModel);
            _carRepository.EditCar(car);
         
        }

        public List<CarModel> GetAllCars()
        {
            var cars = _carRepository.GetAllCars();
            var carModels = _mapper.Map<List<CarModel>>(cars);
            return carModels;
        }

        public CarModel GetCarById(int? id)
        {
            var carInBd = _carRepository.GetCarById(id);
            var carModel = _mapper.Map<CarModel>(carInBd);
            return carModel;
        }

        public CarModel GetCarByRegisterNumber(string number)
        {
            var carInBd = _carRepository.GetCarByRegisterNumber(number);
            var carModel = _mapper.Map<CarModel>(carInBd);
            return carModel;
        }

        public List<CarModel> GetCarsForAsign(DateTime date, EnumDayParts part, int? categoryId)
        {    
            var cars= _carRepository.GetCarsForAsign(date, part, categoryId);
            var carModels = _mapper.Map<List<CarModel>>(cars);
            return carModels;
        }
    }
}
