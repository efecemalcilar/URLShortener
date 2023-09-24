using System.Linq.Expressions;
using URLShortener.IRepository;
using URLShortener.UnitOfWorks;

namespace URLShortener.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<T> Addasync(T entity)
        {
            await _repository.Addasync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            return await _repository.RemoveAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
