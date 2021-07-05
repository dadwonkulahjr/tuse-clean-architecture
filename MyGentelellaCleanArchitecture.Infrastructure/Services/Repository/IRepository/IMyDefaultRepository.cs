using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository
{
    public interface IMyDefaultRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAllRelatedEntityAsync(Expression<Func<T, bool>> fiterType = null,
                      string myNavigationProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderType = null);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(T entityType);
        Task AddAsync(T entityToAdd);
        Task<T> GetFirstOrDefaultEntityTypeAsync(Expression<Func<T, bool>> filterType = null,
            string myNavigationProperties = null);
        void RemoveEntity(T entityToRemoveObj);
        void RemoveEntity(int entityToRemoveId);




    }
}
