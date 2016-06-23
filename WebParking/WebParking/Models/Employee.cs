using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Required(ErrorMessage = "!!!")]
        //[Display(Name = "Name")]
        public string Contact { get; set; }
        //[Required(ErrorMessage = "!!!")]
        //[Display(Name = "Contact")]
        public string Post { get; set; }
        //[Required(ErrorMessage = "!!!")]
        //[Display(Name = "Post")]

        public virtual ICollection<Car> Cars { get; set; }

    }
}