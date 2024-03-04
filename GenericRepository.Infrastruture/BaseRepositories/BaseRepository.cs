using GenericRepository.Application.Abstractions;
using GenericRepository.Domain.Entites.DTOs.Persistance;
using GenericRepository.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Infrastruture.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly GenericRepositoryDbContext _dbContext;

        private readonly DbSet<T> _dbSet;
        private DbSet<User> dbSet;

        public BaseRepository(GenericRepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public BaseRepository(GenericRepositoryDbContext dbContext, DbSet<User> dbSet) : this(dbContext)
        {
            this.dbSet = dbSet;
        }

        public async Task<T> Create(T entity)
        {   
            var result = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            if (result == null)
            {
                return false;
            }
            _dbSet.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();    
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(expression);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update( T entity)
        {
            var result = _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity; 
        }
    }
}
 