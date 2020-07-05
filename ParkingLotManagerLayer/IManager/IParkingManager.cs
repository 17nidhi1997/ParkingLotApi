using ParkingLotCommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagerLayer.IManager
{
   public interface IParkingManager
    {
        object GetDetail();
        object GetParkingById(int parkingId);
        object GetParkingByNum(String Vehiclenum);
        object GetParkingByVType(int VehicleType);
        object Parkinglot(Parking parking);
        object UnParking(int parkingID);
    }
}
