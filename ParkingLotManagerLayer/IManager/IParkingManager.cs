using ParkingLotCommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagerLayer.IManager
{
   public interface IParkingManager
    {
        object ParkingStatus();
        object SearchById(int parkingId);
        object SearchByNum(String Vehiclenum);
        object SearchByVType(int VehicleType);
        object ParkingDitails(Parking parking);
        object UnParking(int parkingID);
        object parlingLot();
    }
}
