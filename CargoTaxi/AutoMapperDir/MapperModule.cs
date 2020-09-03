using Autofac;
using AutoMapper;
using Business.Models;
using CargoTaxi.Data.Models;
using CargoTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.AutoMapperDir
{
    public class MapperModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderModel>().ReverseMap();
                cfg.CreateMap<Car, CarModel>().ReverseMap();
                cfg.CreateMap<CarPostViewModel, CarModel>().ReverseMap();
                cfg.CreateMap<CarCategory, CarCategoryModel>().ReverseMap();
                cfg.CreateMap<ApplicationUser, UserModel>().ReverseMap();
                cfg.CreateMap<UserModel, UserViewModel>().ReverseMap();
                cfg.CreateMap<UserModel, ClientViewModel>().ReverseMap();
                cfg.CreateMap<CarModel, CarViewModel>().ReverseMap();
                cfg.CreateMap<CarModel, CreateCarViewModel>().ReverseMap();
                cfg.CreateMap<CarCategoryModel, CarCategoryViewModel>().ReverseMap();
                cfg.CreateMap<OrderModel, OrderViewModel>().ReverseMap();
               /* cfg.CreateMap<OrderModel, EditOrderPostModel>().ReverseMap();*///.ForMember(m=>m.Category, opt=>opt.Ignore()).ForMember(m => m.Client, opt => opt.Ignore()).ForMember(m => m.Car, opt => opt.Ignore())
                cfg.CreateMap<OrderModel, CreateOrderPostModel>().ReverseMap();
                cfg.CreateMap<UserModel, EditClientPostModel>().ReverseMap();
                cfg.CreateMap<CreateOrderPostModel, MessageViewModel>().ReverseMap();
                cfg.CreateMap<OrderPostModel, OrderModelForUpdate>().ReverseMap();
                cfg.CreateMap<OrderPropForUpdate, OrderModelForUpdate>().ReverseMap();
                cfg.CreateMap<UserModel, DriverPostModel>().ReverseMap();
                cfg.CreateMap<ChangeOrderViewModel, EditOrderPostModel>().ReverseMap();
                cfg.CreateMap<OrderModel, ChangeOrderViewModel >()                
                .ForMember(m => m.ClientPhoneNumber, opt => opt.MapFrom(src => src.Client.PhoneNumber)).ReverseMap();                
                cfg.CreateMap<EditOrderPostModel, OrderModel>().ReverseMap();                
                cfg.CreateMap<CreateOrderPostModel, MessageViewModel>().ReverseMap();//
                cfg.CreateMap<ClientOrderViewModel, OrderModel>().ReverseMap();
                cfg.CreateMap<OrderModel, DriverOrderViewModel>().ForMember(m => m.Date, opt => opt.MapFrom(src => src.Date.ToShortDateString()))
                .ForMember(m => m.CarCategory, opt => opt.MapFrom(src => src.Category.Name.ToString()))
                .ForMember(m => m.Car, opt => opt.MapFrom(src => src.Car.RegistrNumber))
                .ForMember(m => m.ClientPhone, opt => opt.MapFrom(src => src.Client.PhoneNumber));
                  
                cfg.CreateMap<OrderModel, ClientOrderViewModel>().ForMember(m => m.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(x => x.Car, opts => opts.MapFrom(src => src.Car.RegistrNumber == null ? "Не назначено" : src.Car.RegistrNumber));
            })).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}