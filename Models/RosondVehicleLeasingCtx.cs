using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RosondVehicleLeasing.Models
{
    public class RosondVehicleLeasingCtx : DbContext
    {
        public RosondVehicleLeasingCtx() :
            base("RosondVehicleLeasingConnection")
        {
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}