using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using URLShortener.IRepository;

namespace URLShortener.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShortenerDbContext _dbcontex;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ShortenerDbContext dbcontext)
        {
            _dbcontex = dbcontext;
            _dbSet = dbcontext.Set<T>();
        }
        public async Task<T> Addasync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
