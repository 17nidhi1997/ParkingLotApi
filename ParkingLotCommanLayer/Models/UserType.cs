using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCommanLayer.Models
{
    public class UserType
    {     
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

