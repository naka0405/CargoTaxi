using AutoMapper;
using Business.Interfaces;
using CargoTaxi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CargoTaxi.Controllers.Api
{
    public class DriverApiController : ApiController
    {
        private readonly IDriverService _driverService;
        private readonly IDriverHelperService _driverHelperService;
        private readonly IMapper _mapper;
        public DriverApiController(IDriverHelperService driverHelperService, IMapper mapper, IDriverService driverService)
        {
            _driverHelperService = driverHelperService;
            _mapper = mapper;
            _driverService = driverService;
        }

       // [Route("api/DriverApi/get/{startDate}/{finishDate}")]
        public IEnumerable<OrderViewModel> Get([FromUri]  DateTime? startDate=null , [FromUri] DateTime? finishDate=null)
        {
           var id = User.Identity.GetUserId();
            var driverOrders = _driverService.GetMyOrders(id, startDate=null, finishDate=null);
            var driverOrdersBl = _mapper.Map<List<OrderViewModel>>(driverOrders);
            return driverOrdersBl;
        }

        //public string Get()
        //{
        //    return "IS IT WORK?!?";
        //}
    }
}
