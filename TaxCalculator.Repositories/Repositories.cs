using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaxCalculator.EntityBase.Context;

namespace TaxCalculator.Repositories
{
    public class Repository<T> : IRepositories<T> where T : class
    {
        protected readonly TaxCalculatorDbContext DbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(TaxCalculatorDbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();            
            
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {

            return await _dbSet.AnyAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
