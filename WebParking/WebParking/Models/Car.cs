using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}