using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotCommanLayer.Models;
using ParkingLotManagerLayer.IManager;
using Serilog;

namespace ParkingLotAPIs.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        public IParkingManager _Manager;
        public PoliceController(IParkingManager manager)
        {
            this._Manager = manager;
        }

        [HttpPost]
        [Route("Parkinglot")]
        public IActionResult Parkinglot(Parking parking)
        {
            var item = this._Manager.Parkinglot(parking);
            return this.Ok(item);
        }

        [HttpGet]
        [Route("GetParkingByNum")]
        public IActionResult GetParkingByNum(String Vehiclenum)
        {
            Log.Information("list is displayed");
            var item = this._Manager.GetParkingByNum(Vehiclenum);
            return this.Ok(item);
        }

        [HttpGet]
        [Route("GetParkingByVType")]
        public IActionResult GetParkingByVType(int VehicleType)
        {
            Log.Information("list is displayed");
            var item = this._Manager.GetParkingByVType(VehicleType);
            return this.Ok(item);
        }
    }
}