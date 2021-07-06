using MyGentelellaCleanArchitecture.Domain.Enities;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository
{
    public interface IStudentRepository : IMyDefaultRepository<Student>
    {
        Task Update(Student studentToUpdate);
    }
}
