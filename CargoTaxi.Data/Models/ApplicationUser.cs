using CargoTaxi.Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CargoTaxi.Data.Models
{
    public class ApplicationUser : IdentityUser,IActiveDriver
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DriverLicense { get; set; }

        public IList<Order> Orders { get; set; }
        public IList<Car> Cars { get; set; }
        public bool IsActiveDriver { get; set ; }

        public ApplicationUser()
        {
            IsActiveDriver = false;
            Orders = new List<Order>();
            Cars = new List<Car>();
        }

    }
}
