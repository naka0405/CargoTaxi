using Business.Models;
using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;


namespace Business.Interfaces
{
    public interface ICarService
    {       
        CarModel GetCarById(int? id);
        CarModel GetCarByRegisterNumber(string number);
        void CreateCar(CarModel car);
        void EditCar(CarModel car);
        void DeleteCar(int id);
        List<CarModel> GetAllCars();
        List<CarModel> GetCarsForAsign(DateTime date, EnumDayParts part, int? categoryId);
    }
}
