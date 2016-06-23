using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ParkingSystem.Models
{
    public class AppContext : DbContext
    {
        //public AppContext() : base("DefaultConnection") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}