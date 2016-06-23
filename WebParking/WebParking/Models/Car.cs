using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Number { get; set; }
        //[Required(ErrorMessage = "!!!")]
       // [Display(Name = "Number")]
        public string Mark { get; set; }
       // [Required(ErrorMessage = "!!!")]
      //  [Display(Name = "Mark")]
        public string Model { get; set; }
       // [Required(ErrorMessage = "!!!")]
       // [Display(Name = "Model")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}