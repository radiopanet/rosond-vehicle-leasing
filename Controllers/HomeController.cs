using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosondVehicleLeasing.Models;
using System.Data.Entity;

namespace RosondVehicleLeasing.Controllers
{
    public class HomeController : Controller
    {
        //Inject the context class
        private RosondVehicleLeasingCtx db = new RosondVehicleLeasingCtx();

        
        public ActionResult Index()
        {
            var vehicleManufactures = db.Vehicles.Select(v => v.Make).Distinct().ToList();

            //Group by Branch
            var branchReport = db.Branches
                .Include(b => b.Vehicles) // load related vehicles
                .ToList()
                .Select(b => new VehicleManufacturerVM
                {
                    Group = b.BranchName,
                    VehicleManCount = b.Vehicles
                    .GroupBy(v => v.Make)
                    .ToDictionary(g => g.Key, g => g.Count())
                })
                .ToList();

            //Group by Client
            var clientReport = db.Clients
                .Include(c => c.Vehicles) // load related vehicles
                .ToList()
                .Select(c => new VehicleManufacturerVM
                {
                    Group = c.CompanyName,
                    VehicleManCount = c.Vehicles
                        .GroupBy(v => v.Make)
                        .ToDictionary(g => g.Key, g => g.Count())
                })
                .ToList();


            // Group by Supplier
            var supplierReport = db.Suppliers
                .Include(s => s.Vehicles) // load related vehicles
                .ToList() 
                .Select(s => new VehicleManufacturerVM
                {
                    Group = s.SupplierName,
                    VehicleManCount = s.Vehicles
            .GroupBy(v => v.Make)
            .ToDictionary(g => g.Key, g => g.Count())
                })
            .ToList();


            ViewBag.Suppliers = supplierReport;
            ViewBag.Branches = branchReport;
            ViewBag.Clients = clientReport;
            ViewBag.Manufacturers = vehicleManufactures;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}