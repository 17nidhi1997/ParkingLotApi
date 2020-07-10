using ParkingLotCommanLayer.Models;
using ParkingLotManagerLayer.IManager;
using ParkingLotRepoLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagerLayer.ManegerImplementation
{
   public class ParkingManager : IParkingManager
    {
       private IParkingRepository _Parking;
        public ParkingManager(IParkingRepository parkings)
        {
            _Parking = parkings;
        }

        public object ParkingStatus()
        {
            return this._Parking.ParkingStatus();
        }

        public object SearchById(int parkingId)
        {
            return this._Parking.SearchById(parkingId);
        }

        public object SearchByNum(String Vehiclenum)
        {
            return this._Parking.SearchByNum(Vehiclenum);
        }

        public object SearchByVType(int VehicleType)
        {
            return this._Parking.SearchByVType(VehicleType);
        }

        public object ParkingDitails(Parking parking)
        {
            return this._Parking.ParkingDitails(parking);
        }

        public object UnParking(int parkingID)
        {
            return this._Parking.UnParking(parkingID);
        }

        public object parlingLot()
        {
            return this._Parking.parlingLot();
        }
    }
}

