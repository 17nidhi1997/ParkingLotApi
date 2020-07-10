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
        MSMQ msmq = new MSMQ();
        public OwnerController(IParkingManager manager)
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
        [Route("ParkingStatus")]
        public IActionResult ParkingStatus()
        {
            Log.Information("list is displayed");
            var item = this._Manager.ParkingStatus();
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
        [HttpPut]
        [Route("UnParking")]
        public IActionResult UnParking(int parkingID)
        {
            var item = this._Manager.UnParking(parkingID);
            msmq.SendMessage("UnParking vehicle:", item);
            return this.Ok(item);
        }

    }
}