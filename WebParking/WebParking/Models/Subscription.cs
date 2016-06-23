using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingSystem.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime ExpirtionDate { get; set; }
        public int Cost { get; set; }
        //[Required(ErrorMessage = "!!!")]
        //[Display(Name = "Cost")]
        public int PlaceNumber { get; set; }
        //[Required(ErrorMessage = "!!!")]
        //[Display(Name = "PlaceNumber")]
        public int ParkingId { get; set; }
        public int CarId { get; set; }
        public virtual Parking Parking { get; set; }
        public virtual Car Car { get; set; }
    }
}