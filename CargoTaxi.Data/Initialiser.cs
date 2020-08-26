using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CargoTaxi.Data.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Runtime.InteropServices.ComTypes;

namespace CargoTaxi.Data
{
    public class Initialiser:CreateDatabaseIfNotExists<TaxiDbContext>
    {
        protected override void Seed(TaxiDbContext context)
        {
            var minCategory = new CarCategory() 
            {
                Name = EnumCategories.Minimum,
                LoadTonCapacity = 1,
                HeightCargoSpace = 1.6,
                WidthCargoSpace=1.5,
                LengthCargoSpace=3
            };
            var standartCategory = new CarCategory()
            {
                Name = EnumCategories.Standart,
                LoadTonCapacity = 1.2,
                HeightCargoSpace = 1.7,
                WidthCargoSpace = 1.5,
                LengthCargoSpace = 4
            };
            var maxCategory = new CarCategory()
            {
                Name = EnumCategories.Maximum,
                LoadTonCapacity = 1.5,
                HeightCargoSpace = 1.7,
                WidthCargoSpace = 1.5,
                LengthCargoSpace = 4
            };
            context.CarCategories.AddRange(new List<CarCategory>() { minCategory, standartCategory, maxCategory });
            context.SaveChanges();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            var roleDriver = new IdentityRole() { Name = "Driver" };
            var roleClient = new IdentityRole() { Name = "Client" };
            var roleAdmin = new IdentityRole() { Name = "Admin" };

            roleManager.Create(roleDriver);
            roleManager.Create(roleClient);
            roleManager.Create(roleAdmin);

            var admin = new ApplicationUser 
            {
                Email = "Somemail@mail.ru",
                UserName = "Somemail@mail.ru",
                FirstName="Petr",
                LastName="Petrov",
                PhoneNumber="0666105545",
                PasswordHash= "ad46D_ewr3"
            };
            string password = "ad46D_ewr3";
            var adminResult = userManager.Create(admin, password);
            if (adminResult.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, roleAdmin.Name);
                userManager.AddToRole(admin.Id, roleClient.Name);
            }

            var driver1 = new ApplicationUser() 
            {
                LastName = "Andreev",
                FirstName="Andrey",
                UserName = "Driver1mail@mail.ru",
                DriverLicense = "77 77 123456",
                PhoneNumber = "0501234567",
                Email= "Driver1mail@mail.ru",
                IsActiveDriver=true
            };
            var driver1Result = userManager.Create(driver1, password);
            if (driver1Result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(driver1.Id, roleDriver.Name);
                userManager.AddToRole(driver1.Id, roleClient.Name);
            }
            var car1 = new Car() { RegistrNumber = "Ax112345Xa", CategoryId = 1};
            driver1.Cars.Add(car1);

            var driver2 = new ApplicationUser()
            {
                FirstName="Sergey",
                LastName = "Sergeev",
                UserName = "Driver2mail@mail.ru",
                DriverLicense = "33 44 654321",
                PhoneNumber = "0997654321",
                Email = "Driver2mail@mail.ru",
                IsActiveDriver = true
            };
           
            var driver2Result = userManager.Create(driver2, password);
            if (driver2Result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(driver2.Id, roleDriver.Name);
                userManager.AddToRole(driver2.Id, roleClient.Name);
            }
            var car2 = new Car() { RegistrNumber = "Am654987Xa", CategoryId = 3 };
            var car3 = new Car() { RegistrNumber = "Xa526341Xa", CategoryId = 2 };
            driver2.Cars.Add(car2);
            driver2.Cars.Add(car3);

            var driver3 = new ApplicationUser()
            {
                FirstName= "Ivan",
                LastName = "Ivanov",
                UserName = "Driver3mail@mail.ru",
                DriverLicense = "53 44 111111",
                PhoneNumber = "0677650021",
                Email = "Driver3mail@mail.ru",
                IsActiveDriver = true
            };
            var driver3Result = userManager.Create(driver3, password);
            if (driver3Result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(driver3.Id, roleDriver.Name);
                userManager.AddToRole(driver3.Id, roleClient.Name);
            }
            var car4 = new Car() { RegistrNumber = "Bl789456Z", CategoryId = 2 };
            driver3.Cars.Add(car4);

            var client1 = new ApplicationUser()
            { 
                FirstName="Olga",
                UserName = "Client1mail@mail.ru",
                LastName = "Sokolova",
                PhoneNumber = "0973459615",
                Email = "Client1mail@mail.ru"
            };
            var client1Result = userManager.Create(client1, password);
            if (client1Result.Succeeded)
            {
                // добавляем для пользователя роль               
                userManager.AddToRole(client1.Id, roleClient.Name);
            }
            var order1 = new Order()
            {
                Number = "01/15/08/20",
                Date = new DateTime(2020, 08, 16),
                StartTime="15-45",
                CarCategoryId = 2,
                StartAdress = "Волонтерская 74/37",
                FinishAdress = "Холодногорская 6",                
                CarId=3, 
                Car=car3
            };
            client1.Orders.Add(order1);
            var client2 = new ApplicationUser()
            {
                FirstName ="Anna",
                UserName = "Client2mail@mail.ru",
                LastName = "Petuhova",
                PhoneNumber = "0959651201",
                Email = "Client2mail@mail.ru"
            };
            var client2Result = userManager.Create(client2, password);
            if (client2Result.Succeeded)
            {
                // добавляем для пользователя роль               
                userManager.AddToRole(client2.Id, roleClient.Name);
            }
            var order2 = new Order()
            {
                Number = "01/15/08/20",
                Date = new DateTime(2020, 08, 18),
                StartTime = "15-00",
                CarCategoryId = 1,
                StartAdress = "Geroev Truda 18-81",
                FinishAdress = "Illinskaja 63/16",                
                CarId=1,
                Car=car1
            };
            client2.Orders.Add(order2);
            
            context.Orders.AddRange(new List<Order>() { order1, order2 });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
