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
                cfg.CreateMap<CarModel, CarViewModel>().ReverseMap();
                cfg.CreateMap<CarCategoryModel, CarCategoryViewModel>().ReverseMap();
                cfg.CreateMap<OrderModel, OrderViewModel>().ReverseMap();
                cfg.CreateMap<OrderModel, CreateOrderPostModel>().ReverseMap();
                cfg.CreateMap<UserModel, EditClientPostModel>().ReverseMap();
                cfg.CreateMap<MessageViewModel,CreateOrderPostModel>().ReverseMap();
                cfg.CreateMap<OrderPostModel, OrderModelForUpdate>().ReverseMap();
                cfg.CreateMap<OrderPropForUpdate, OrderModelForUpdate>().ReverseMap();
                cfg.CreateMap<UserModel, DriverPostViewModel>().ReverseMap();
               // cfg.CreateMap<RegisterUser, UserModel>().ReverseMap();
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