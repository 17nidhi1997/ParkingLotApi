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
    public class SecurityController : ControllerBase
    {
        public IParkingManager _Manager;
        MSMQ msmq = new MSMQ();
        public SecurityController(IParkingManager manager)
        {
            this._Manager = manager;
        }

        [HttpPost]
        public IActionResult ParkingDitails(Parking parking)
        {
            var item = this._Manager.ParkingDitails(parking);
            return this.Ok(item);
        }

        [HttpGet]
        [Route("SearchById")]
        public IActionResult SearchById(int parkingId)
        {
            Log.Information("list is displayed");
            var item = this._Manager.SearchById(parkingId);
            return this.Ok(item);
        }

        [HttpGet]
        [Route("SearchByNum")]
        public IActionResult SearchByNum(String Vehiclenum)
        {
            Log.Information("list is displayed");
            var item = this._Manager.SearchByNum(Vehiclenum);
            return this.Ok(item);
        }

        [HttpGet]
        [Route("SearchByVType")]
        public IActionResult SearchByVType(int VehicleType)
        {
            Log.Information("list is displayed");
            var item = this._Manager.SearchByVType(VehicleType);
            return this.Ok(item);
        }

        [HttpPut]
        [Route("UnParking")]
        public IActionResult UnParking(int parkingID)
        {
            var item = this._Manager.UnParking(parkingID);
            msmq.SendMessage("UnParking vehicle:",item);
            return this.Ok(item);
        }
    }
}