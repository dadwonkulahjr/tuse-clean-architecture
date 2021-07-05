using System;

namespace MyGentelellaCleanArchitecture.Domain.Enities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime? DateEnrolled { get; set; }
     
    }
}
