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
    public class DriverController : ControllerBase
    {
        public IParkingManager _Manager;
        public DriverController(IParkingManager manager)
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
        [Route("parlingLot")]
        public IActionResult parlingLot()
        {
            Log.Information("list is displayed");
            var item = this._Manager.parlingLot();
            return this.Ok(item);
        }

        [HttpPut]
        public IActionResult UnParking(int parkingID)
        {
            var item = this._Manager.UnParking(parkingID);
            return this.Ok(item);
        }

    }
}