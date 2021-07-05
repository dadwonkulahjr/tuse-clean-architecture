using Microsoft.EntityFrameworkCore;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyGentelellaCleanArchitecture.Infrastructure.Services.Repository
{
    public class MyDefaultRepository<TEntity> : IMyDefaultRepository<TEntity> where TEntity : class
    {
        protected internal DbContext _dbContext;
        internal DbSet<TEntity> _dbSetQuery;
        public MyDefaultRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSetQuery = dbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entityToAdd)
        {
            await _dbSetQuery.AddAsync(entityToAdd);
        }
        public async Task<IEnumerable<TEntity>> GetAllRelatedEntityAsync(Expression<Func<TEntity, bool>> fiterType = null, string myNavigationProperties = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderType = null)
        {
            IQueryable<TEntity> query = _dbSetQuery;

            if (fiterType != null)
            {
                query = query.Where(fiterType);
            }


            if (myNavigationProperties != null)
            {
                foreach (var property in myNavigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (orderType != null)
            {
                return await orderType(query).ToListAsync();
            }

            return await query.ToListAsync();

        }
        public async Task<TEntity> GetAsync(int id)
        {
            var find = await _dbSetQuery.FindAsync(id);
            if(find != null)
            {
                return find;
            }
            return null;
        }
        public async Task<TEntity> GetAsync(TEntity entityType)
        {
            return await _dbSetQuery.FindAsync(entityType);
        }
        public async Task<TEntity> GetFirstOrDefaultEntityTypeAsync(Expression<Func<TEntity, bool>> filterType = null, string myNavigationProperties = null)
        {
            IQueryable<TEntity> query = _dbSetQuery;

            if (filterType != null)
            {
                query = query.Where(filterType);
            }


            if (myNavigationProperties != null)
            {
                foreach (var property in myNavigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
        public void RemoveEntity(TEntity entityToRemoveObj)
        {
            _dbSetQuery.Remove(entityToRemoveObj);
        }
        public void RemoveEntity(int entityToRemoveId)
        {
            var findEntity = _dbSetQuery.Find(entityToRemoveId);
            if(findEntity != null)
            {
                _dbSetQuery.Remove(findEntity);
            }
        }
    }
}
