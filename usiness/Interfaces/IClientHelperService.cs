using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IClientHelperService
    {
        List<CarCategoryModel> GetAllCategory();
        UserModel GetClientById(string Id);
        CarCategoryModel GetCarCategoryById(int? id);
        CarModel GetCarById(int? id);
    }
}
