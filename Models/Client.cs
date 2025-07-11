using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RosondVehicleLeasing.Models
{
    public class Client
    {
        [Display(Name ="Client")]
        public int ClientId { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        //A client may lease one or more vehicles.
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}