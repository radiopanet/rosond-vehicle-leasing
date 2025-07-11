using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RosondVehicleLeasing.Models
{
    public class Vehicle
    {
        [Display(Name="Vehicle")]
        public int VehicleId { get; set; }
        [Required]
        [Display(Name="Manufacturer")]
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        [Display(Name ="Procurement Date")]
        public DateTime ProcumentDate { get; set; }


        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver{ get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

       
    }
}