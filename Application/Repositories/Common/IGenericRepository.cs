using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Repositories.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<object> InsertAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task DeleteAsync(object id, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Dispose();

        IQueryable<TEntity> GetAllQuery();
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAllQuery(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null);



        IQueryable<TEntity> GetSingleQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> GetLastRow(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, bool>> orderBy, CancellationToken cancellationToken = default);
    }
}
