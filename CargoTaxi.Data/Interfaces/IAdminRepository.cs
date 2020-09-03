using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IAdminRepository
    {
        //Обработка заявки(назначить машину, если на его View виден заказ от клиента и доступные машины(на эту дату и по габаритам груза))
        //Отмена заявки
        void CreateCar(Car car);
        void DeleteCar(int id);
        //void CreateDriver(int id);
        void DeactivateDriver(int id);
        void AssignCar(int orderId, int carId, string number);
        void DeleteOrder(string number);
    }
}
