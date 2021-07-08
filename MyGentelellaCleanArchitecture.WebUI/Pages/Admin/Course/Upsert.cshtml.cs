using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using MyGentelellaCleanArchitecture.WebUI.ViewModels;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.WebUI.Pages.Admin.Course
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public CourseVM CourseVM { get; set; } = new();
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                CourseVM = new();
                CourseVM.GetDropdownListForCourse = _unitOfWork.Course.GetDropdownSelectListItemForCourse();
                return Page();
            }

            if (id.HasValue)
            {
                CourseVM.Course = await _unitOfWork.Course.GetFirstOrDefaultEntityTypeAsync(s => s.CourseId == id.Value);

                CourseVM.GetDropdownListForCourse = _unitOfWork.Course.GetDropdownSelectListItemForCourse();
                CourseVM.GetDropdownListForCourseHrs = _unitOfWork.Course.GetDropdownSelectListItemForCourseHrs();
                CourseVM.GetDropdownListForCourseNum = _unitOfWork.Course.GetDropdownSelectListItemForCourseNum();

                CourseVM.Student = await _unitOfWork.Student.GetFirstOrDefaultEntityTypeAsync(s => s.StudentId == CourseVM.Course.StudentId);

                return Page();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (CourseVM.Course.CourseId == 0)
            {
                //Add new record...
                await _unitOfWork.Course.AddAsync(CourseVM.Course);
                await _unitOfWork.SaveAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                //Update existing record...
                foreach (var key in Request.Form.Keys)
                {

                }

                await _unitOfWork.Course.Update(CourseVM.Course);
                return RedirectToPage("./Index");

            }
        }
    }
}
