using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosondVehicleLeasing.Models
{
    public class Driver
    {
        [Display(Name ="Driver")]
        public int DriverId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="License Number")]
        public string LicenseNumber { get; set; }
        [Display(Name ="Expiry Date")]
        public DateTime LicenseExpiry { get; set; }
        //A driver may drive one or more vehicle
        public virtual ICollection<Vehicle> Vehicles{get; set; }
    }
}