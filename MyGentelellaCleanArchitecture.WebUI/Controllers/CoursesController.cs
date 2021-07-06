using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courseList = await _unitOfWork.Course.GetAllRelatedEntityAsync(myNavigationProperties:"Student");

            return Json(new { data = courseList.ToList() });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _unitOfWork.Course.GetFirstOrDefaultEntityTypeAsync(s => s.CourseId == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }

            _unitOfWork.Course.RemoveEntity(obj);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true, message = "Delete successful" });

        }

    }
}
