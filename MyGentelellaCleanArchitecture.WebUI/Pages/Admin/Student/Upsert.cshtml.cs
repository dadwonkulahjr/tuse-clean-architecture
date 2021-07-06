using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.WebUI.Pages.Admin.Student
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Domain.Enities.Student StudentObj { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                StudentObj = new();
                return Page();
            }

            if (id.HasValue)
            {
                StudentObj = await _unitOfWork.Student.GetFirstOrDefaultEntityTypeAsync(s => s.StudentId == id.Value);

                return Page();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid) return Page();


            if (StudentObj.StudentId == 0)
            {
                //Add new record...
                await _unitOfWork.Student.AddAsync(StudentObj);
                await _unitOfWork.SaveAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                //Update existing record...
                await _unitOfWork.Student.Update(StudentObj);
                return RedirectToPage("./Index");

            }
        }
    }
}
