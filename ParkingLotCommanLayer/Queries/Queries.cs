using ParkingLotCommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCommanLayer.Quaries
{
   public class Queries
    {
        public static string ParkingStatusQuery = "SELECT * FROM PARKINGLOT.Parking";
        public static string SearchByIdQuery = "Select * from PARKINGLOT.Parking where Id=";
        public static string SearchByNumQuery = "Select * from PARKINGLOT.Parking where VehicleNumber=";
        public static string SearchByVTypeQuery = "Select * from PARKINGLOT.Parking where PVehicleId=";
        public static string ParkingDitailsQuery = "insert into PARKINGLOT.Parking(Id ,ParkingSLot ,VehicleNumber ,EntryTime ,PVehicleId ,PParkingId ,PRoleId ,Disabled ,ExitTime) values(:Id,:ParkingSLot,:VehicleNumber,:EntryTime,:PVehicleId,:PParkingId,:PRoleId,:Disabled,:ExitTime)";
        public static string UnParkingUpdateQuery = "UPDATE PARKINGLOT.Parking SET Disabled = 'TRUE',ExitTime=current_timestamp WHERE ID=";
        public static string UnParkingSelectQuery = "Select * from PARKINGLOT.Parking where Id=";
        public static string UnParkingRolesQuery = "Select * from PARKINGLOT.Roles where RolesId =";
        public static string parlingLotQuery= "SELECT COUNT(*) FROM PARKINGLOT.Parking";
        public static string parlingLotQuery1 = "SELECT COUNT(*) FROM PARKINGLOT.Parking WHERE DISABLED = 'TRUE'";


    }
}
