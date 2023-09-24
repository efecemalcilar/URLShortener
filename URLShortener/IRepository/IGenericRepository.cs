using System.Linq.Expressions;

namespace URLShortener.IRepository
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<T> Addasync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
      

    }
}
