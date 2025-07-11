namespace RosondVehicleLeasing.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RosondVehicleLeasing.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RosondVehicleLeasing.Models.RosondVehicleLeasingCtx>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RosondVehicleLeasing.Models.RosondVehicleLeasingCtx context)
        {
            //  This method will be called after migrating to the latest version.

            // Prevent duplicate seed
            if (context.Suppliers.Any()) return;

            var branch1 = new Branch { BranchName = "Sandton Branch", Location = "Johannesburg", Manager = "Thabo Radiopane" };
            var branch2 = new Branch { BranchName = "Mangaung", Location = "Bloemfontein", Manager = "Simon Daniels" };

            var client1 = new Client { CompanyName = "Blues Car Hire", EmailAddress="admin@bch.co.za", PhoneNumber="010-285-6932" };
            var client2 = new Client { CompanyName = "Hemingway Logistics", EmailAddress="admin@hemingway.com", PhoneNumber="015-898-6369" };

            var driver1 = new Driver { FirstName = "Thabo", LastName = "Maine", LicenseNumber = "TH12BC GP", LicenseExpiry=new DateTime(2030,05,31) };
            var driver2 = new Driver { FirstName = "Mpho", LastName = "Nthupi", LicenseNumber = "TH65BA GP", LicenseExpiry= new DateTime(2028, 12, 31)   };

            var supplier1 = new Supplier { SupplierName = "CarsForAll", EmailAddress="info@carsforall.co.za", PhoneNumber = "016-123-4567", Address="20 Sloane Avenue Bryanston" };
            var supplier2 = new Supplier { SupplierName = "Redan Motor Home", EmailAddress="admin@redanmotors.co.za", PhoneNumber = "010-587-6843", Address = "1 Eastern Services Road Redan" };

            var vehicle1 = new Vehicle
            {
                Make = "VW",
                Model = "Polo",
                Year = 2022,
                Supplier = supplier1,
                Branch = branch1,
                Client = client1,
                Driver = driver1,
                ProcumentDate = new DateTime(2022, 10, 25)
            };

            var vehicle2 = new Vehicle
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Supplier = supplier2,
                Branch = branch2,
                Client = client2,
                Driver = driver2,
                ProcumentDate = new DateTime(2023, 6, 29)
            };

            context.Suppliers.AddRange(new[] { supplier1, supplier2 });
            context.Branches.AddRange(new[] { branch1, branch2 });
            context.Clients.AddRange(new[] { client1, client2 });
            context.Drivers.AddRange(new[] { driver1, driver2 });
            context.Vehicles.AddRange(new[] { vehicle1, vehicle2 });

            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }

        }
    }
}
