using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApp.Models;

namespace RestaurantDB.Data
{
    public class RestaurantDBContext : IdentityDbContext
    {
        public RestaurantDBContext (DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
        }


        public DbSet<RestaurantWebApp.Models.Order> Order { get; set; }

        public DbSet<RestaurantWebApp.Models.Customer> Customer { get; set; }

        //public DbSet<RestaurantWebApp.Models.Invoice> Invoice { get; set; }

        public DbSet<RestaurantWebApp.Models.FoodMenu> FoodMenu { get; set; }
    }
}
