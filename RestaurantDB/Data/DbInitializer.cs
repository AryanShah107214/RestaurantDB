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
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.FoodMenu.Any())
            {
                return;   // DB has been seeded
            }

            //Data to be seeded in to the menu
            var foodMenu = new FoodMenu[]
            {
                new FoodMenu { FoodName = "Veg Manchurian", Category="Entrees",Price=6.50,Description="A delicious dish of veggie balls dunked into a sauce with hot and sweet flavors." },
                new FoodMenu { FoodName = "Batata Vada", Category="Entrees",Price=6.50,Description="Tasty platter of fried potato balls with chutneys" },
                new FoodMenu { FoodName = "Samosa (4 Pcs)", Category="Entrees",Price=6.50,Description="A fried or baked pastry with spiced potatoes, onions, peas and other savory ingredients as the filling" },

                new FoodMenu { FoodName = "Undhiyu", Category="Mains",Price=14.00 },
                new FoodMenu { FoodName = "Paneer Tikka Masala", Category="Mains",Price=14.00,Description="A very tasty curry consisting of marinated paneer cheese served in a spiced gravy" },
                new FoodMenu { FoodName = "Paneer Kadhai", Category="Mains",Price=14.00 },
                new FoodMenu { FoodName = "Paneer Saagwala", Category="Mains",Price=14.00 },
                new FoodMenu { FoodName = "Shahi Paneer", Category="Mains",Price=14.00 },
                new FoodMenu { FoodName = "Jeera Aloo", Category="Mains",Price=14.00 },
                new FoodMenu { FoodName = "Dal Makhani", Category="Mains",Price=14.00,Description="A creamy and smooth lentil soup " },
                new FoodMenu { FoodName = "Poori Bhaji", Category="Mains",Price=14.00 },
                new FoodMenu { FoodName = "Malai Kofta", Category="Mains",Price=14.00, Description="A vegetarian curry consisting of crisp friend potato panner fried balls served with a creamy and smooth gravy." },
                new FoodMenu { FoodName = "Dum Aloo", Category="Mains",Price=14.00 },

                new FoodMenu { FoodName = "Gulab Jamun", Category="Deserts",Price=9.00,Description="Fried dough balls served in a sweet sugar syrup." },
                new FoodMenu { FoodName = "Halwa", Category="Deserts",Price=9.00 },
                new FoodMenu { FoodName = "Ras Malai", Category="Deserts",Price=9.00 },
                new FoodMenu { FoodName = "Rasgulla", Category="Deserts",Price=9.00 },
                new FoodMenu { FoodName = "Mango Barfi", Category="Deserts",Price=9.00 },
                new FoodMenu { FoodName = "Boondi Ladoo", Category="Deserts",Price=9.00 },
                new FoodMenu { FoodName = "Jalebi", Category="Deserts",Price=9.00,Description="A deep-fried sweet snack made of sugar syrup shaped like a big pretzel" },

                new FoodMenu { FoodName = "Masala Chai", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Filter Coffee", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Mango Lassi", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Coke", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Pepsi", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Fanta", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Sprite", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Orange Juice", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Apple Juice", Category="Drinks",Price=6.00 },
                new FoodMenu { FoodName = "Tropical Juice", Category="Drinks",Price=6.00 },
            };

            context.FoodMenu.AddRange(foodMenu);
            context.SaveChanges();//adds and saves it to the database and displays it on the web page

            //data to be seeded in to the customers page
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
            context.SaveChanges();//adds and saves it to the database and displays it on the web page

            //data to be seeded in to the orders page
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
            context.SaveChanges();//adds and saves it to the database and displays it on the web page
        }
    }
}