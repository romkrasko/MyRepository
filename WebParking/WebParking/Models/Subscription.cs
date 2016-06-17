using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime ExpirtionDate { get; set; }
        public int Cost { get; set; }
        public int PlaceNumber { get; set; }
        public int ParkingId { get; set; }
        public int CarId { get; set; }
        public virtual Parking Parking { get; set; }
        public virtual Car Car { get; set; }
    }
}