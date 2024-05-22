using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Models.Core;

namespace Data.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbEntities _dbContext;
        private readonly DbSet<TEntity> dbSet;
        protected BaseRepository(DbEntities context)
        {
            this._dbContext = context ?? throw new ArgumentException(nameof(context));
            dbSet = _dbContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return dbSet.Add(entity).Entity;

        }

        public virtual void Update(Guid id, TEntity entity)
        {
            TEntity local = dbSet.Find(id);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Patch<TModel>(TEntity entity, TModel updatedModel) where TModel : BaseDTO
        {
            bool modified = false;
            // copy the value of properties from view model into entity
            PropertyInfo[] entityProperties = entity.GetType().GetProperties();
            foreach (PropertyInfo entityPropertyInfo in entityProperties)
            {
                PropertyInfo updatedModelPropertyInfo = updatedModel.GetType().GetProperty(entityPropertyInfo.Name);
                if (updatedModelPropertyInfo != null)
                {
                    var value = updatedModelPropertyInfo.GetValue(updatedModel, null);
                    if (value != null)
                    {
                        entityPropertyInfo.SetValue(entity, value, null);
                        modified = true;
                    }
                }
            }
            if (modified)
            {
                this.Update(entity.Id, entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
        public virtual void Delete(List<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }
        public virtual void Delete(QueryBuilder<TEntity> baseQuery)
        {
            IEnumerable<TEntity> objects = GetQueryable(baseQuery).AsEnumerable();
            dbSet.RemoveRange(objects);
        }

        public virtual IEnumerable<TEntity> GetAll(QueryBuilder<TEntity> baseQuery)
        {
            return GetQueryable(baseQuery).AsEnumerable();
        }

        public virtual TEntity? GetOne(QueryBuilder<TEntity> baseQuery)
        {
            return GetQueryable(baseQuery).FirstOrDefault();
        }
        public virtual TEntity? GetById(Guid id, List<string>? includeProperties = null)

        {
            QueryBuilder<TEntity> getByIdQuery = QueryBuilder<TEntity>.FilterQuery(e => e.Id == id, includeProperties);
            return GetQueryable(getByIdQuery).FirstOrDefault();
        }

        public virtual int GetCount(QueryBuilder<TEntity> baseQuery)
        {
            return GetQueryable(baseQuery).Count();
        }
        public virtual bool Any(QueryBuilder<TEntity> baseQuery)
        {
            return GetQueryable(baseQuery).Any();
        }

        protected virtual IQueryable<TEntity> GetQueryable(QueryBuilder<TEntity> baseQuery)

        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();


            // Filter by isDeleted property
            query = query.Where(entity => !entity.IsDeleted);


            if (baseQuery.Criteria != null)
            {
                query = query.Where(baseQuery.Criteria);
            }
            if (baseQuery.Includes.Count > 0)
            {
                foreach (var includeProperty in baseQuery.Includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (baseQuery.OrderBy != null)
            {
                query = query.OrderBy(baseQuery.OrderBy);
            }
            else if (baseQuery.OrderByDescending != null)
            {
                query = query.OrderByDescending(baseQuery.OrderByDescending);
            }

            if (baseQuery.PageNumber.HasValue && baseQuery.PageSize.HasValue)
            {
                int skip = (baseQuery.PageNumber.Value - 1) * baseQuery.PageSize.Value;
                query = query.Skip(skip);
            }

            if (baseQuery.PageSize.HasValue)
            {
                query = query.Take(baseQuery.PageSize.Value);
            }
            return query;
        }
    }
}
