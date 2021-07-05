namespace MyGentelellaCleanArchitecture.Domain.Enities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseHour { get; set; }
        public int CourseNumber { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
