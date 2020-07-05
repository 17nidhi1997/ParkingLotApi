using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotCommanLayer.Models;
using ParkingLotManagerLayer.IManager;

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
        [Route("Parkinglot")]
        public IActionResult Parkinglot(Parking parking)
        {
            var item = this._Manager.Parkinglot(parking);
            return this.Ok(item);
        }
        
    }
}