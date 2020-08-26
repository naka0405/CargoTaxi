using CargoTaxi.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.Models
{
    public class RegisterUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public string Password { get; set; }
        public string DriverLicense { get; set; }
        public bool IsActiveDriver { get; set; }
    }
}