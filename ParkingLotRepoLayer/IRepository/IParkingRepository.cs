using ParkingLotCommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotRepoLayer.IRepository
{
    public interface IParkingRepository
    {
        IEnumerable<Parking> ParkingStatus();
        IEnumerable<Parking> SearchById(int parkingId);
        IEnumerable<Parking> SearchByNum(String Vehiclenum);
        IEnumerable<Parking> SearchByVType(int VehicleType);
        object ParkingDitails(Parking parking);
        object UnParking(int parkingID);
        object parlingLot();

    }
}
