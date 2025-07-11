using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RosondVehicleLeasing.Models;

namespace RosondVehicleLeasing.Controllers
{
    public class VehiclesController : Controller
    {
        private RosondVehicleLeasingCtx db = new RosondVehicleLeasingCtx();

        // GET: Vehicles
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Branch).Include(v => v.Client).Include(v => v.Driver).Include(v => v.Supplier);
            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "CompanyName");
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,Make,Model,Year,ProcumentDate,BranchId,ClientId,DriverId,SupplierId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", vehicle.BranchId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "CompanyName", vehicle.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName", vehicle.DriverId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", vehicle.SupplierId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", vehicle.BranchId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "CompanyName", vehicle.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName", vehicle.DriverId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", vehicle.SupplierId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,Make,Model,Year,ProcumentDate,BranchId,ClientId,DriverId,SupplierId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", vehicle.BranchId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "CompanyName", vehicle.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName", vehicle.DriverId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", vehicle.SupplierId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
