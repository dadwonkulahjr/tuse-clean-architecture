using System.ComponentModel.DataAnnotations;

namespace MyGentelellaCleanArchitecture.Domain.Enities
{
    public class Course
    {
        [Display(Name ="Course name"), Required]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Display(Name ="Course hour")]
        [Required]
        public int CourseHour { get; set; }
        [Display(Name = "Course number")]
        [Required]
        public int CourseNumber { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
