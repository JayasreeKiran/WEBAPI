using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
    
    public class Listing
    {
        public string Name { get; set; }
        public decimal PricePerPassenger { get; set; }

        public VehicleType vehicleType = new VehicleType();
        public decimal TotalPrice { get; set; }
    }
    public class VehicleType
    {
        public string Name { get; set; }

        public int MaxPassengers { get; set; }
    }
}