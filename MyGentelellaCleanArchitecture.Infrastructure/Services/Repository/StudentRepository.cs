using MyGentelellaCleanArchitecture.Domain.Enities;
using MyGentelellaCleanArchitecture.Infrastructure.Persistence;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository
{
    public class StudentRepository : MyDefaultRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public StudentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }
        public async Task Update(Student studentToUpdate)
        {
            var find = await _appDbContext.Student.FindAsync(studentToUpdate.StudentId);
            if (find != null)
            {
                find.FirstName = studentToUpdate.FirstName;
                find.LastName = studentToUpdate.LastName;
                find.Email = studentToUpdate.Email;
                find.DateEnrolled = studentToUpdate.DateEnrolled;
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
