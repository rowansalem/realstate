using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Infrastructure.Repositories
{
    public class QueryBuilder<TEntity>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
        public List<string> Includes { get; set; } = new List<string>();
        public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDescending { get; set; } = null;
        public int? PageSize { get; set; } = null;
        public int? PageNumber { get; set; } = null;

        public QueryBuilder(Expression<Func<TEntity, bool>>? criteria = null,
            List<string>? includes = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            int? pageSize = null,
            int? pageNumber = null)
        {
            Criteria = criteria;
            Includes = includes ?? new List<string>();
            OrderBy = orderBy;
            OrderByDescending = orderByDescending;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        #region factory methods

        public static QueryBuilder<TEntity> FilterQuery(Expression<Func<TEntity, bool>>? criteria = null,
            List<string>? includeProperties = null)
        {
            return new QueryBuilder<TEntity>(criteria, includeProperties);
        }
        public static QueryBuilder<TEntity> FilterSortQuery(Expression<Func<TEntity, bool>>? criteria = null,
            List<string>? includeProperties = null,
            Expression<Func<TEntity, object>> orderBy = null,
            bool isAscending = true)
        {
            QueryBuilder<TEntity> baseQuery = new QueryBuilder<TEntity>(criteria, includeProperties);
            if (isAscending)
                baseQuery.OrderBy = orderBy;
            else
                baseQuery.OrderByDescending = orderBy;
            return baseQuery;
        }

        public static QueryBuilder<TEntity> PagedQuery(Expression<Func<TEntity, bool>>? criteria,
            List<string>? includeProperties,
            int pageNumber,
            int pageSize,
            bool isAscending,
            Expression<Func<TEntity, object>>? orderBy = null)
        {
            QueryBuilder<TEntity> baseQuery = new QueryBuilder<TEntity>(criteria,
                includeProperties);
            baseQuery.PageNumber = pageNumber;
            baseQuery.PageSize = pageSize;
            if (isAscending)
                baseQuery.OrderBy = orderBy;
            else
                baseQuery.OrderByDescending = orderBy;
            return baseQuery;

        }


        #endregion

    }
}
