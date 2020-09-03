using CargoTaxi.Data.Models;
using CargoTaxi.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface ICarRepository
    {        
        Car GetCarById(int? id);
        Car GetCarByRegisterNumber(string number);
        void CreateCar(Car car);
        void EditCar(Car car);
        void DeleteCar(int id);
        List<Car> GetAllCars();
        List<Car> GetCarsForAsign(DateTime date, EnumDayParts part, int? categoryId);
    }
}
