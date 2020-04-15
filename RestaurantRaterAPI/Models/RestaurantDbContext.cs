using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class RestaurantDbContext : DbContext //Had to install entity framework first, then using system.data.entity
    {
        //We actually aren't going to do much in here right now. The plan is to code in away that our database is made for us.


        public RestaurantDbContext() : base("DefaultConnection") { } //This is like our empty constructor for the class
        public DbSet<Restaurant> Restaurants { get; set; } //This is like our property for the class
    }
}