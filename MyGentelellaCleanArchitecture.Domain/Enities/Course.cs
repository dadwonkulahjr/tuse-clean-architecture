using System.ComponentModel.DataAnnotations;

namespace MyGentelellaCleanArchitecture.Domain.Enities
{
    public class Course
    {
        [Display(Name ="Course name")]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [Display(Name ="Course hour")]
        public int CourseHour { get; set; }
        [Display(Name = "Course number")]
        public int CourseNumber { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
