using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RosondVehicleLeasing.Models
{
    public class Branch
    {
        [Display(Name="Branch")]
        public int BranchId { get; set; }
        [Required]
        [Display(Name="Branch Name")]
        public string BranchName { get; set; }
        [Display(Name="Branch Manager")]
        public string Manager { get; set; }
        public string Location { get; set; }

        //One branch have many vehicles.(1:M)
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}