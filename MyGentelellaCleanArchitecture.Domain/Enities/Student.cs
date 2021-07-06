using System;
using System.ComponentModel.DataAnnotations;

namespace MyGentelellaCleanArchitecture.Domain.Enities
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name ="First name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }
        [Required]
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
