using Microsoft.EntityFrameworkCore;
using MyGentelellaCleanArchitecture.Domain.Enities;
using System;
using System.Collections.Generic;

namespace MyGentelellaCleanArchitecture.Infrastructure.Persistence.Configurations
{
   public static class ExtendModelBuilder
    {
        public static ModelBuilder SeedDatabaseWithInitialData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasData(GetMyListOfStudents);
            modelBuilder.Entity<Course>()
                        .HasData(GetMyListOfCourses);

            return modelBuilder;
        }
        private static IEnumerable<Student> GetMyListOfStudents
        {
            get
            {
                return new List<Student>()
                {
                    new()
                    {
                        StudentId = 1,
                        FirstName = "iamtuse",
                        LastName = "theDeveloper",
                        DateEnrolled= DateTime.UtcNow,
                        Email = "iamtuse@iamtuse.com"
                    },

                    new()
                    {
                        StudentId = 2,
                        FirstName = "Leo",
                        LastName = "Maxwell",
                        DateEnrolled= DateTime.UtcNow,
                        Email = "leo@iamtuse.com"
                    },

                      new()
                    {
                        StudentId = 3,
                        FirstName = "Precious",
                        LastName = "Wonkulah",
                        DateEnrolled= DateTime.UtcNow,
                        Email = "wonkulahp@iamtuse.com"
                    },
                };
            }
        }
        private static IEnumerable<Course> GetMyListOfCourses
        {
            get
            {
                return new List<Course>()
                {
                    new()
                    {
                        CourseId = 1,
                        CourseName = "Software Development",
                        StudentId = 1,
                        CourseHour = 8,
                        CourseNumber = 301,
                    },
                    new()
                    {
                        CourseId = 2,
                        CourseName = "Razor Pages",
                        StudentId = 1,
                        CourseHour = 8,
                        CourseNumber = 302,
                    },
                    new()
                    {
                        CourseId = 3,
                        CourseName = "MVC",
                        StudentId = 2,
                        CourseHour = 10,
                        CourseNumber = 302,
                    },
                    new()
                    {
                        CourseId = 4,
                        CourseName = "Advanced Database Management",
                        StudentId = 3,
                        CourseHour = 6,
                        CourseNumber = 201,
                    },
                    new()
                    {
                        CourseId = 5,
                        CourseName = "Advanced Web Development",
                        StudentId = 3,
                        CourseHour = 10,
                        CourseNumber = 400,
                    }
                };
            }
        }
    }
}
