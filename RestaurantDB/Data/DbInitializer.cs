using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantDB.Models;

namespace RestaurantDB.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RestaurantDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.FoodMenu.Any())
            {
                return;   // DB has been seeded
            }

            var foodMenu = new FoodMenu[]
            {
                new FoodMenu { FoodName = "Veg Manchurian", Category="Entree",Price=650 },
                new FoodMenu { FoodName = "Batata Vada", Category="Entree",Price=650 },
                new FoodMenu { FoodName = "Samosa (4 Pcs)", Category="Entree",Price=650 },
                new FoodMenu { FoodName = "Sabudana Vada (5 Pcs)", Category="Entree",Price=650 },

                new FoodMenu { FoodName = "Undhiyu", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Paneer Tikka Masala", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Paneer Kadhai", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Paneer Saagwala", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Shahi Paneer", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Jeera Aloo", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Dal Makhani", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Poori Bhaji", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Malai Kofta", Category="Main",Price=1400 },
                new FoodMenu { FoodName = "Dum Aloo", Category="Main",Price=1400 },

                new FoodMenu { FoodName = "Gulab Jamun", Category="Desert",Price=900 },
                new FoodMenu { FoodName = "Halwa", Category="Desert",Price=900 },
                new FoodMenu { FoodName = "Ras Malai", Category="Desert",Price=900 },
                new FoodMenu { FoodName = "Rasgulla", Category="Desert",Price=900 },
                new FoodMenu { FoodName = "Mango Barfi", Category="Desert",Price=900 },
                new FoodMenu { FoodName = "Boondi Ladoo", Category="Desert",Price=900 },
                new FoodMenu { FoodName = "Jalebi", Category="Desert",Price=900 },

                new FoodMenu { FoodName = "Masala Chai", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Filter Coffee", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Mango Lassi", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Coke", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Pepsi", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Fanta", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Sprite", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Orange Juice", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Apple Juice", Category="Drinks",Price=600 },
                new FoodMenu { FoodName = "Tropical Juice", Category="Drinks",Price=600 },
            };

            context.FoodMenu.AddRange(foodMenu);
            context.SaveChanges();

            var Customer = new Customer[]
            {
                new Customer { LastName = "Adams", FirstName = "Jack", Email = "adambandler@gmail.com", PhoneNumber = 0278542364 },
                new Customer { LastName = "Sparks", FirstName = "Brooklyn", Email = "brooklynsparks@gmail.com", PhoneNumber = 0211958465 },
                new Customer { LastName = "Wilson", FirstName = "Sam", Email = "samwilson@gmail.com", PhoneNumber = 0226451354 },
                new Customer { LastName = "Shah", FirstName = "Aryan", Email = "adambandler@gmail.com", PhoneNumber = 0278542364 },
                new Customer { LastName = "Eti", FirstName = "Brooklyn", Email = "brooklyneti@gmail.com", PhoneNumber = 0278542364 },
                new Customer { LastName = "Sese", FirstName = "Cyruss", Email = "cyrusssese@gmail.com", PhoneNumber = 0278542364 }
            };

            context.Customer.AddRange(Customer);
            context.SaveChanges();

            var Order = new Order[]
{
                new Order { OrderItem="Fanta",Quantity=1,SpiceLevel="N/A",Cost=6.00,CustomerID=1 },
                new Order { OrderItem="Gulab Jamun",Quantity=1,SpiceLevel="N/A",Cost=9.00,CustomerID=1 },
                new Order { OrderItem="Paneer Tikka Masala",Quantity=1,SpiceLevel="Hot",Cost=14.00,CustomerID=1 },

                new Order { OrderItem="Sprite",Quantity=1,SpiceLevel="",Cost=6.00,CustomerID=2 },
                new Order { OrderItem="Mango Barfi",Quantity=1,SpiceLevel="",Cost=9.00,CustomerID=2 },
                new Order { OrderItem="Undhiyu",Quantity=1,SpiceLevel="Medium",Cost=14.00,CustomerID=2 },

                new Order { OrderItem="Veg Manchurian",Quantity=1,SpiceLevel="",Cost=6.50,CustomerID=3 },
                new Order { OrderItem="Fanta",Quantity=2,SpiceLevel="",Cost=12.00,CustomerID=3 },
                new Order { OrderItem="Malai Kofta",Quantity=1,SpiceLevel="Medium-Hot",Cost=14.00,CustomerID=3 },
                new Order { OrderItem="Shahi Paneer",Quantity=1,SpiceLevel="Mild-Medium",Cost=14.00,CustomerID=3 },




};

            context.Order.AddRange(Order);
            context.SaveChanges();
        }
    }
}