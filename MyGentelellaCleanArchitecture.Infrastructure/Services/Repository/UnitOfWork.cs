using MyGentelellaCleanArchitecture.Infrastructure.Persistence;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _appDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
            Student = new StudentRepository(applicationDbContext);
            Course = new CourseRepository(applicationDbContext);
        }

        public IStudentRepository Student { get; private set; }
        public ICourseRepository Course { get; private set; }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
