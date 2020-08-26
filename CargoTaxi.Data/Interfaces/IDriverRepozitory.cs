using CargoTaxi.Data.Models;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    interface IDriverRepozitory
    {
        void CreateDriver(RegisterUser driver);
        void UpdateDriver(ApplicationUser driver);
        void DeactivateDriver(string id);
        List<ApplicationUser> GetAllDrivers();
    }
}
