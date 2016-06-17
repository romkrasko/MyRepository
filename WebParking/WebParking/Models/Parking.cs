using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int PlaceCount { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}