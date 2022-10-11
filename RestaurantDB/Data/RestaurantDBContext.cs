using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantDB.Models;

namespace RestaurantDB.Data
{
    public class RestaurantDBContext : IdentityDbContext
    {
        public RestaurantDBContext (DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
        }


        public DbSet<RestaurantDB.Models.Order> Order { get; set; }

        public DbSet<RestaurantDB.Models.Customer> Customer { get; set; }

        //public DbSet<RestaurantDB.Models.Invoice> Invoice { get; set; }

        public DbSet<RestaurantDB.Models.FoodMenu> FoodMenu { get; set; }


    }
}
