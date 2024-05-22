
using System;
using System.Linq.Expressions;

namespace Data.Infrastructure.Helpers

{
    public static class ExpressionHelper
    {
        public static Expression<Func<TEntity, object>> GetPropertySelector<TEntity>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var propertyInfo = typeof(TEntity).GetProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property {propertyName} not found on type {typeof(TEntity).Name}");
            }

            var propertyExpression = Expression.Property(parameter, propertyInfo);
            var convertExpression = Expression.Convert(propertyExpression, typeof(object));
            var lambda = Expression.Lambda<Func<TEntity, object>>(convertExpression, parameter);

            return lambda;
        }
    }
}