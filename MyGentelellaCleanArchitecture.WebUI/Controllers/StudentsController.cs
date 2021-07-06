using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studentInfoList = await _unitOfWork.Student.GetAllRelatedEntityAsync();

            return Json(new { data = studentInfoList.ToList() });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _unitOfWork.Student.GetFirstOrDefaultEntityTypeAsync(s => s.StudentId == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }

            _unitOfWork.Student.RemoveEntity(obj);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true, message = "Delete successful" });

        }

    }
}
