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
    public class OwnerController : ControllerBase
    {
        public IParkingManager _Manager;
        public OwnerController(IParkingManager manager)
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
        [Route("GetDetail")]
        public IActionResult GetDetails()
        {
            Log.Information("list is displayed");
            var item = this._Manager.GetDetail();
            return this.Ok(item);
        }

        [HttpGet]
        [Route("GetParkingById")]
        public IActionResult GetParkingById(int parkingId)
        {
            Log.Information("list is displayed");
            var item = this._Manager.GetParkingById(parkingId);
            return this.Ok(item);
        }
        [HttpPut]
        [Route("UnParking")]
        public IActionResult UnParking(int parkingID)
        {
            var item = this._Manager.UnParking(parkingID);
            return this.Ok(item);
        }

    }
}