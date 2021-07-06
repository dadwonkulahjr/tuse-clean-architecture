using System;
using System.ComponentModel.DataAnnotations;

namespace MyGentelellaCleanArchitecture.Domain.Enities
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name ="Fullname")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name = "Date Enrolled")]
        public DateTime DateEnrolled { get; set; }
     
    }
}
