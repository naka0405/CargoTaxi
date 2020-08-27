using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class AllClientOrdersViewModel
    {
        public IEnumerable<ClientOrderViewModel> Orders { get; set; }

    }
}