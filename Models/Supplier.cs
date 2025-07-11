using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RosondVehicleLeasing.Models
{
    public class Supplier
    {
        [Display(Name ="Supplier")]
        public int SupplierId { get; set; }
        [Required]
        [Display(Name ="Supplier Name")]
        public string SupplierName { get; set; }
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        //A supplier supplies multiple vehicles.
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}