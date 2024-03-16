using System.Linq.Expressions;

namespace ggsport.Infrastructure;

public interface IService<TEntity>
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entityToUpdate);
    Task DeleteAsync(int id);
}
