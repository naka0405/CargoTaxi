using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Business.Interfaces;
using Business.Services;
using CargoTaxi.AutoMapperDir;
using CargoTaxi.Data;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using CargoTaxi.Data.Repozitories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Http;
using System.Web.Mvc;

namespace CargoTaxi.Autofac
{
    public class AutofacConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterApiControllers(typeof(Controllers.API.AnimalController).Assembly);


            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<DriverRepository>().As<IDriverRepository>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            builder.RegisterType<AdminRepository>().As<IAdminRepository>();
            //builder.RegisterType<ClientHelperRepozitory>().As<IClientHelper>();
            //builder.RegisterType<DriverHelperRepozitory>().As<IDriverHelper>();
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<CarCategoryRepository>().As<ICarCategoryRepository>();

            builder.RegisterType<CarCategoryService>().As<ICarCategoryService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<DriverService>().As<IDriverService>();
           // builder.RegisterType<AdminService>().As<IAdminService>();
           // builder.RegisterType<ClientHelperService>().As<IClientHelperService>();
            builder.RegisterType<CarService>().As<ICarService>();

            builder.RegisterType<TaxiDbContext>().InstancePerRequest();
            builder.RegisterModule<MapperModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var ctx = new TaxiDbContext();
            builder.Register<TaxiDbContext>(x => ctx);
            builder.Register<UserStore<ApplicationUser>>(x => new UserStore<ApplicationUser>(ctx)).AsImplementedInterfaces();
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>());
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            //builder.Register<IdentityFactoryOptions<RoleManager>> (c => new IdentityFactoryOptions<RoleManager>());
            builder.RegisterType<RoleManager<IdentityRole>> ();
            builder.RegisterType<ApplicationUserManager>();

            //var x = new ApplicationDbContext();
            //builder.Register<ApplicationDbContext>(c => x);
            //builder.Register<UserStore<ApplicationUser>>(c => new UserStore<ApplicationUser>(x)).AsImplementedInterfaces();
            //builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            //{
            //    DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            //});
            //builder.RegisterType<ApplicationUserManager>();

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}