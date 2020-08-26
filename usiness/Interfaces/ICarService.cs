using Business.Models;
using System.Collections.Generic;


namespace Business.Interfaces
{
    public interface ICarService
    {
        CarModel GetCarById(int id);
        void CreateCar(CarModel car);
        void EditCar(CarModel car);
        void DeleteCar(int id);
        List<CarModel> GetAllCars();
    }
}
