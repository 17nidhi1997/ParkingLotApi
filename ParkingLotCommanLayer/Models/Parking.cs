using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotCommanLayer.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public int ParkingSLot { get; set; }
        public string VehicleNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public int PVehicleId { get; set; }
        public int PParkingId { get; set; }
        public int PRoleId { get; set; }
        public string Disabled { get; set; }
        public DateTime ExitTime { get; set; }

    }
}

