using Business.Models;

namespace Business.Interfaces
{
    public interface IAdminService
    {
        void CreateCar(CarModel car);
        void DeleteCar(int id);
        void CreateDriver(int id);
        void DeactivateDriver(int id);
        void AssignCar(int orderId, int carId);
        void DeleteOrder(string number);
    }
}
