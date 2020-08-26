
using CargoTaxi.Data.Models;
using System.Collections.Generic;

namespace CargoTaxi.Data.Interfaces
{
    public interface IClientHelper
    {
        List<CarCategory> GetAllCategory();
        ApplicationUser GetClientById(string Id);
        CarCategory GetCarCategoryById(int? id);
        Car GetCarById(int? id);
    }
}
