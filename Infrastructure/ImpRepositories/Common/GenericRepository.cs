using Application.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.ImpRepositories.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        // Instance of the DbContext. Must be passed or injected.        
        private DbContext Context { get; set; }
        public GenericRepository(DbContext context)
        {
            Context = context;

        }

        //Internally re-usable DbSet instance.
        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<TEntity>();
                return _dbSet;
            }
        }
        private DbSet<TEntity> _dbSet;

        #region Async Members
        public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this.DbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.Where(match).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.FirstOrDefaultAsync(match, cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await this.DbSet.CountAsync(cancellationToken);
        }

        public virtual async Task<object> InsertAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            var rtn = await this.DbSet.AddAsync(entity);
            if (saveChanges)
            {
                ////Debugging use.
                //try
                //{
                await Context.SaveChangesAsync(cancellationToken);
                //}
                //catch (Exception ex)
                //{
                //    var te = ex;
                //}
            }
            return rtn;
        }

        public virtual async Task DeleteAsync(object id, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            this.DbSet.Remove(GetById(id));
            if (saveChanges)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return null;
            var exist = await this.DbSet.FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    await Context.SaveChangesAsync(cancellationToken);
                }
            }
            return exist;
        }

        public virtual async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }


        private TEntity GetById(object id, CancellationToken cancellationToken = default)
        {
            return this.DbSet.Find(id);
        }

        #endregion

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IQueryable<TEntity> GetAllQuery()
        {
            return this.GetAllQuery(null, null, null, null, null);
        }
        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetAllQuery(predicate, null, null, null, null);
        }

        public IQueryable<TEntity> GetAllQuery(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return this.GetAllQuery(null, include, null, null, null);
        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return this.GetAllQuery(predicate, include, null, null, null);
        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }


        public IQueryable<TEntity> GetSingleQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQueryable(predicate, include);

            return query;
        }
        private IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = this.DbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            return query;
        }

        public async Task<TEntity> GetLastRow(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, bool>> orderBy, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.Where(match).OrderByDescending(orderBy).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
