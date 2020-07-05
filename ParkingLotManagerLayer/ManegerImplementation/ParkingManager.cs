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

        public object GetDetail()
        {
            return this._Parking.GetDetail();
        }

        public object GetParkingById(int parkingId)
        {
            return this._Parking.GetParkingById(parkingId);
        }

        public object GetParkingByNum(String Vehiclenum)
        {
            return this._Parking.GetParkingByNum(Vehiclenum);
        }

        public object GetParkingByVType(int VehicleType)
        {
            return this._Parking.GetParkingByVType(VehicleType);
        }

        public object Parkinglot(Parking parking)
        {
            return this._Parking.Parkinglot(parking);
        }

        public object UnParking(int parkingID)
        {
            return this._Parking.UnParking(parkingID);
        }
    }
}

