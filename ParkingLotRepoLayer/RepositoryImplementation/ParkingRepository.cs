﻿using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using ParkingLotCommanLayer.Models;
using ParkingLotCommanLayer.Quaries;
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
        private readonly IConfiguration configuration;
        public ParkingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<Parking> ParkingStatus()
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.ParkingStatusQuery;
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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

        public IEnumerable<Parking> SearchById(int parkingId)
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.SearchByIdQuery + parkingId+"";
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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
        public IEnumerable<Parking> SearchByNum(String Vehiclenum)
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.SearchByNumQuery + Vehiclenum + "";
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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

        public object parlingLot()
        {
            OracleConnection _db=new OracleConnection(configuration.GetConnectionString("UserDbConnection"));
            _db.Open();
            OracleCommand cmd = new OracleCommand(Queries.parlingLotQuery, _db);
            var count = cmd.ExecuteScalar();
            cmd.Dispose();
            cmd.Dispose();
           
            OracleCommand cmd1 = new OracleCommand(Queries.parlingLotQuery1, _db);
            var counts = cmd1.ExecuteScalar();
            cmd.Dispose();
            cmd.Dispose();
            var parkings = Convert.ToInt32( count ) - Convert.ToInt32(counts);
            var parkingLotDetails = 400 - parkings;
            return parkingLotDetails;
        }
        public IEnumerable<Parking> SearchByVType(int VehicleType)
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.SearchByVTypeQuery + VehicleType + "";
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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

        public object ParkingDitails(Parking parking)
        {
            var commandText = Queries.ParkingDitailsQuery;
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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
                return parking.Id+ "=Parking ID is sucessfull added";
            }
        }

        public object UnParking(int parkingID)
        {
            var commandText = Queries.UnParkingUpdateQuery + parkingID + "";
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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
            var commandTexts = Queries.UnParkingSelectQuery + parkingID + ""; 
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
            using (OracleCommand cmd = new OracleCommand(commandTexts, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
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
            List<Roles> list1 = new List<Roles>();
            var commandTextss = Queries.UnParkingRolesQuery + parking.PRoleId + "";
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
            using (OracleCommand cmd = new OracleCommand(commandTextss, _db))
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
                    return roles.Charges;
                }
                else
                {
                    return Math.Round(Convert.ToDouble(roles.Charges) * differenceInTime);
                }
            }
        }
         
        public void Connection()
        {
            Console.WriteLine("Starting.\r\n");
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
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

