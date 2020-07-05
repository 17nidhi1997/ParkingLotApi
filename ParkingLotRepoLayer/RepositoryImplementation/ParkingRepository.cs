using Oracle.ManagedDataAccess.Client;
using ParkingLotCommanLayer.Models;
using ParkingLotRepoLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotRepoLayer.RepositoryImplementation
{
    public class ParkingRepository : IParkingRepository
    {
        public IEnumerable<Parking> GetDetail()
        {
            List<Parking> list = new List<Parking>();
            var commandText = "SELECT * FROM PARKINGLOT.Parking";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        public IEnumerable<Parking> GetParkingById(int parkingId)
        {
            List<Parking> list = new List<Parking>();
            var commandText = "Select * from PARKINGLOT.Parking where Id=" + parkingId + "";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }
        public IEnumerable<Parking> GetParkingByNum(String Vehiclenum)
        {
            List<Parking> list = new List<Parking>();
            var commandText = "Select * from PARKINGLOT.Parking where VehicleNumber=" + Vehiclenum + "";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }


        public IEnumerable<Parking> GetParkingByVType(int VehicleType)
        {
            List<Parking> list = new List<Parking>();
            var commandText = "Select * from PARKINGLOT.Parking where PVehicleId=" + VehicleType + "";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        public object Parkinglot(Parking parking)
        {
            var commandText = "insert into PARKINGLOT.Parking(Id ,ParkingSLot ,VehicleNumber ,EntryTime ,PVehicleId ,PParkingId ,PRoleId ,Disabled ,ExitTime) values(:Id,:ParkingSLot,:VehicleNumber,:EntryTime,:PVehicleId,:PParkingId,:PRoleId,:Disabled,:ExitTime)";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.Parameters.Add("Id", parking.Id);
                cmd.Parameters.Add("ParkingSLot", parking.ParkingSLot);
                cmd.Parameters.Add("VehicleNumber", parking.VehicleNumber);
                cmd.Parameters.Add("EntryTime", parking.EntryTime);
                cmd.Parameters.Add("PVehicleId", parking.PVehicleId);
                cmd.Parameters.Add("PParkingId", parking.PParkingId);
                cmd.Parameters.Add("PRoleId", parking.PRoleId);
                cmd.Parameters.Add("Disabled", parking.Disabled);
                cmd.Parameters.Add("ExitTime", parking.ExitTime);
                _db.Open();
                cmd.ExecuteNonQuery();
                _db.Close();
                return "sucessfull added";
            }
        }

        public object UnParking(int parkingID)
        {
            var commandText = "UPDATE PARKINGLOT.Parking SET Disabled = 'TRUE',ExitTime=current_timestamp WHERE ID=" + parkingID + "";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                _db.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("Disabled", "True");
                cmd.Parameters.Add("ExitTime", "current_timestamp");
                cmd.ExecuteNonQuery();
                _db.Close();
            }

            List<Parking> list = new List<Parking>();
            Parking parking = new Parking();
            var commandTexts = "Select * from PARKINGLOT.Parking where Id=" + parkingID + "";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(commandTexts, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
            }
            Roles roles = new Roles();
            System.TimeSpan diff = parking.ExitTime.Subtract(parking.EntryTime);
            var differenceInTime = diff.TotalHours;
            // return differenceInTime;
            List<Roles> list1 = new List<Roles>();
            var Charges = "Select Charges from Roles where RolesId =" + parking.PRoleId + "";
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            using (OracleCommand cmd = new OracleCommand(Charges, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.RolesId = Convert.ToInt32(reader["RolesId"]);
                    roles.Role = reader["Role"].ToString();
                    roles.Charges = Convert.ToInt32(reader["Charges"]);
                    list1.Add(roles);
                }
                _db.Close();
                if (differenceInTime <= 1)
                {
                    return Charges;
                }
                else
                {
                    return Math.Round(Convert.ToDouble(Charges) * differenceInTime);
                }
            }
        }
    

        
        public void Connection()
        {
            Console.WriteLine("Starting.\r\n");
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            {
                Console.WriteLine("Open connection...");
                _db.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = _db;
                cmd.CommandText =
                "begin " +
                " execute immediate 'create table PARKINGLOT.UserType(UserId int NOT NULL PRIMARY KEY ,Email varchar2(20) not null,Password varchar2(20) not null ,Role varchar2(20) not null)';" +
                " execute immediate 'create table PARKINGLOT.VehicleType(VehicleId int NOT NULL PRIMARY KEY,VehicleTypes varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOT.ParkingType(ParkingId int NOT NULL PRIMARY KEY ,ParkingTypes varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOT.Roles(RolesId int NOT NULL PRIMARY KEY ,Role varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOT.Parking(Id int NOT NULL PRIMARY KEY ,ParkingSLot varchar2(20) NOT NULL,VehicleNumber varchar2(20) NOT NULL, EntryTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP, PVehicleId int ,PParkingId int ,PRoleId ,FOREIGN KEY(PVehicleId) REFERENCES VehicleType(VehicleId), FOREIGN KEY(PParkingId) REFERENCES ParkingType(ParkingId) ,FOREIGN KEY(PRoleId ) REFERENCES Roles(RolesId))';" +
                " execute immediate 'insert into PARKINGLOT.VehicleType(VehicleId,VehicleTypes,Charges) values(001 ,'CAR' ,100.0)';" +
                " execute immediate 'insert into PARKINGLOT.VehicleType(VehicleId,VehicleTypes,Charges) values(002 ,Bike ,50.0)';" +
                " execute immediate 'insert into PARKINGLOT.ParkingType(ParkingId,ParkingTypes,Charges) values(001 ,Vallet ,100.0)';" +
                " execute immediate 'insert into PARKINGLOT.ParkingType(ParkingId,ParkingTypes,Charges) values(002 ,Own ,50.0)';" +
                " execute immediate 'insert into PARKINGLOT.Roles(RolesId,Role,Charges) values(001 ,DRIVER ,100.0)';" +
                " execute immediate 'insert into PARKINGLOT.Roles(RolesId,Role,Charges) values(002 ,POLICE ,30.0)';" +
                " execute immediate 'insert into PARKINGLOT.Roles(RolesId,Role,Charges) values(003 ,SECURITY ,30.0)';" +
                " execute immediate 'insert into PARKINGLOT.Roles(RolesId,Role,Charges) values(004 ,LOTOWNER ,50.0)';" +
                "end;";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                _db.Close();
            }
        }
    }
}

