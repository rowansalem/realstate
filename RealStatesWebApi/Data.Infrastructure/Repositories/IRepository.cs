
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models.Core;

namespace Data.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        void Update(Guid id, TEntity entity);
        void Patch<TModel>(TEntity entity, TModel updatedModel) where TModel : BaseDTO;
        void Delete(TEntity entity);
        void Delete(List<TEntity> entity);
        void Delete(QueryBuilder<TEntity> baseQuery);
        bool Any(QueryBuilder<TEntity> baseQuery);
        int GetCount(QueryBuilder<TEntity> baseQuery);
        TEntity? GetById(Guid id, List<string>? includeProperties = null);
        TEntity? GetOne(QueryBuilder<TEntity> baseQuery);
        IEnumerable<TEntity> GetAll(QueryBuilder<TEntity> baseQuery);
    }
}
