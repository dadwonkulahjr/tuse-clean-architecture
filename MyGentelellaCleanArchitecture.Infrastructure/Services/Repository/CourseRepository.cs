using Microsoft.AspNetCore.Mvc.Rendering;
using MyGentelellaCleanArchitecture.Domain.Enities;
using MyGentelellaCleanArchitecture.Infrastructure.Persistence;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository
{
    public class CourseRepository : MyDefaultRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public CourseRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemForCourse()
        {
            return _appDbContext.Course.Select(c => new SelectListItem()
            {
                Text = c.CourseName,
                Value = c.CourseId.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemForCourseHrs()
        {
            return _appDbContext.Course.Select(c => new SelectListItem()
            {
                Text = c.CourseHour.ToString(),
                Value = c.CourseId.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetDropdownSelectListItemForCourseNum()
        {
            return _appDbContext.Course.Select(c => new SelectListItem()
            {
                Text = c.CourseNumber.ToString(),
                Value = c.CourseId.ToString()
            });
        }
        public async Task Update(Course courseToUpdate)
        {
            var find = await _appDbContext.Course.FindAsync(courseToUpdate.CourseId);
            if (find != null)
            {
                find.CourseName = courseToUpdate.CourseName;
                find.StudentId = courseToUpdate.StudentId;
                await _appDbContext.SaveChangesAsync();
            }
        }

        
    }
}
