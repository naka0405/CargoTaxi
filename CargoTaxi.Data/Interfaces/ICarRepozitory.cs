using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface ICarRepozitory
    {
        Car GetCarById(int id);
        void CreateCar(Car car);
        void EditCar(Car car);
        void DeleteCar(int id);
        List<Car> GetAllCars();
    }
}
