using Microsoft.AspNetCore.Mvc.Rendering;
using MyGentelellaCleanArchitecture.Domain.Enities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository
{
    public interface ICourseRepository : IMyDefaultRepository<Course>
    {
        Task Update(Course courseToUpdate);
        IEnumerable<SelectListItem> GetDropdownSelectListItemForCourse();
        IEnumerable<SelectListItem> GetDropdownSelectListItemForCourseHrs();
        IEnumerable<SelectListItem> GetDropdownSelectListItemForCourseNum();
    }
}
