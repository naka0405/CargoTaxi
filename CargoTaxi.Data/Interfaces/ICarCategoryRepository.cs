using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface ICarCategoryRepository
    {
        CarCategory GetCarCategoryById(int? id);        
        List<CarCategory> GetAllCategories();        
    }
}
