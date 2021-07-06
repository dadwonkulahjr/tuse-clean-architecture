using Microsoft.AspNetCore.Mvc.Rendering;
using MyGentelellaCleanArchitecture.Domain.Enities;
using System.Collections.Generic;

namespace MyGentelellaCleanArchitecture.WebUI.ViewModels
{
    public class CourseVM
    {
        public IEnumerable<SelectListItem> GetDropdownListForCourse { get; set; }
        public IEnumerable<SelectListItem> GetDropdownListForCourseHrs { get; set; }
        public IEnumerable<SelectListItem> GetDropdownListForCourseNum { get; set; }
        public Course Course { get; set; } = new();
        public Student Student { get; set; } = new();
    }
}
