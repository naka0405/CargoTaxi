using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.Data.Interfaces;
using CargoTaxi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    //public class DriverHelperService : IDriverHelperService
    //{
    //    private readonly IDriverHelper _driverHelperRepozitoriy;
    //    private readonly IMapper _mapper;
    //    public DriverHelperService(IDriverHelper helper, IMapper mapper)
    //    {
    //        _mapper = mapper;
    //        _driverHelperRepozitoriy = helper;
    //    }
    //    public UserModel GetDriverById(string id)
    //    {
    //        var driver = _driverHelperRepozitoriy.GetDriverById(id);
    //        var driverBL = _mapper.Map<UserModel>(driver);
    //        return driverBL;
    //    }
   // }
}
