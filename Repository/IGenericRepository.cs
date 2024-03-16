using System.Linq.Expressions;

namespace ggsport.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entityToDelete);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        Task<TEntity?> GetByIdAsync(object id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate);
    }
}