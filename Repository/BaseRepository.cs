using Microsoft.EntityFrameworkCore;
using Dorimuth_Backend.Data.Context;
using Dorimuth_Backend.Repository.Interfaces;

namespace Dorimuth_Backend.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CinemaDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this.GetByIdAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
