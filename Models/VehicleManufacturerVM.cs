using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosondVehicleLeasing.Models
{
    // View Model to pull manufacturers data together with the related groupings(branch, client, supplier)
    public class VehicleManufacturerVM
    {
        public string Group { get; set; }
        public Dictionary<string, int> VehicleManCount { get; set; }
        public int Total => VehicleManCount?.Values.Sum() ?? 0;
    }
}