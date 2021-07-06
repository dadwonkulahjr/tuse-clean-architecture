using System;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IStudentRepository Student { get;}
        public ICourseRepository Course { get;}
        Task SaveAsync();
    }
}
