using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Interfaces
{
    public interface IDriverHelper
    {
        ApplicationUser GetDriverById(string id);
        void UpdateOrder(Order order);

    }
}
