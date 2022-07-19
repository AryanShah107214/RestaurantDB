using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantDB.Models;
using RestaurantWebApp.Models;

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

                
                //new FoodMenu { FirstMidName = "Carson",   LastName = "Alexander",
                //    EnrollmentDate = DateTime.Parse("2016-09-01") },
                //new Student { FirstMidName = "Meredith", LastName = "Alonso",
                //    EnrollmentDate = DateTime.Parse("2018-09-01") },
                //new Student { FirstMidName = "Arturo",   LastName = "Anand",
                //    EnrollmentDate = DateTime.Parse("2019-09-01") },
                //new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                //    EnrollmentDate = DateTime.Parse("2018-09-01") },
                //new Student { FirstMidName = "Yan",      LastName = "Li",
                //    EnrollmentDate = DateTime.Parse("2018-09-01") },
                //new Student { FirstMidName = "Peggy",    LastName = "Justice",
                //    EnrollmentDate = DateTime.Parse("2017-09-01") },
                //new Student { FirstMidName = "Laura",    LastName = "Norman",
                //    EnrollmentDate = DateTime.Parse("2019-09-01") },
                //new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                //    EnrollmentDate = DateTime.Parse("2011-09-01") }
            };

            context.FoodMenu.AddRange(foodMenu);
            context.SaveChanges();

            //var instructors = new Instructor[]
            //{
            //    new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
            //        HireDate = DateTime.Parse("1995-03-11") },
            //    new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
            //        HireDate = DateTime.Parse("2002-07-06") },
            //    new Instructor { FirstMidName = "Roger",   LastName = "Harui",
            //        HireDate = DateTime.Parse("1998-07-01") },
            //    new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
            //        HireDate = DateTime.Parse("2001-01-15") },
            //    new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
            //        HireDate = DateTime.Parse("2004-02-12") }
            //};

            //context.Instructors.AddRange(instructors);
            //context.SaveChanges();

            //var departments = new Department[]
            //{
            //    new Department { Name = "English",     Budget = 350000,
            //        StartDate = DateTime.Parse("2007-09-01"),
            //        InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
            //    new Department { Name = "Mathematics", Budget = 100000,
            //        StartDate = DateTime.Parse("2007-09-01"),
            //        InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
            //    new Department { Name = "Engineering", Budget = 350000,
            //        StartDate = DateTime.Parse("2007-09-01"),
            //        InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
            //    new Department { Name = "Economics",   Budget = 100000,
            //        StartDate = DateTime.Parse("2007-09-01"),
            //        InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            //};

            //context.Departments.AddRange(departments);
            //context.SaveChanges();

            //var courses = new Course[]
            //{
            //    new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
            //        DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
            //    },
            //    new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
            //        DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
            //    },
            //    new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
            //        DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
            //    },
            //    new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
            //        DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
            //    },
            //    new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
            //        DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
            //    },
            //    new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
            //        DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
            //    },
            //    new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
            //        DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
            //    },
            //};

            //context.Courses.AddRange(courses);
            //context.SaveChanges();

            //var officeAssignments = new OfficeAssignment[]
            //{
            //    new OfficeAssignment {
            //        InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
            //        Location = "Smith 17" },
            //    new OfficeAssignment {
            //        InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
            //        Location = "Gowan 27" },
            //    new OfficeAssignment {
            //        InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
            //        Location = "Thompson 304" },
            //};

            //context.OfficeAssignments.AddRange(officeAssignments);
            //context.SaveChanges();

            //var courseInstructors = new CourseAssignment[]
            //{
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Harui").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Harui").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
            //        },
            //    new CourseAssignment {
            //        CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
            //        InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
            //        },
            //};

            //context.CourseAssignments.AddRange(courseInstructors);
            //context.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //    new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
            //        Grade = Grade.A
            //    },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
            //        Grade = Grade.C
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
            //        Grade = Grade.B
            //        },
            //        new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
            //        Grade = Grade.B
            //        },
            //        new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //        CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
            //        Grade = Grade.B
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //        CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
            //        Grade = Grade.B
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Anand").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Anand").ID,
            //        CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
            //        Grade = Grade.B
            //        },
            //    new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
            //        Grade = Grade.B
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Li").ID,
            //        CourseID = courses.Single(c => c.Title == "Composition").CourseID,
            //        Grade = Grade.B
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Justice").ID,
            //        CourseID = courses.Single(c => c.Title == "Literature").CourseID,
            //        Grade = Grade.B
            //        }
            //};

            //foreach (Enrollment e in enrollments)
            //{
            //    var enrollmentInDataBase = context.Enrollments.Where(
            //        s =>
            //                s.Student.ID == e.StudentID &&
            //                s.Course.CourseID == e.CourseID).SingleOrDefault();
            //    if (enrollmentInDataBase == null)
            //    {
            //        context.Enrollments.Add(e);
            //    }
            //}
            context.SaveChanges();
        }
    }
}