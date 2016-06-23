using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Parking
    {
        public int Id { get; set; }
        //[Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "!!!")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        //[Required(ErrorMessage = "!!!")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "!!!")]
        [Display(Name = "PlaceCount")]
        public int PlaceCount { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}