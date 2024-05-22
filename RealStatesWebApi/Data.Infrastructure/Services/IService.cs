using Data.Infrastructure.Exceptions;
using Data.Infrastructure.Helpers;
using Data.Infrastructure.Repositories;
using Models.Core;
using Models.DTO;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Infrastructure.Services
{
    public interface IService<TModel, TDto> where TModel : BaseEntity where TDto : BaseDTO
    {

        TDto GetById(Guid id, List<string>? listOfIncludes = null);
        TDto Create(TDto dto);
        void Update(Guid id, TDto dto);
        void Delete(Guid id);
        void SaveChanges();
        IEnumerable<TDto> GetAll(Expression<Func<TModel, bool>>? criteria = null, List<string>? listOfIncludes = null);
        ApiPaginationResult<TDto> GetAllPaged(FilterModel<TDto> filterModel, List<string>? listOfIncludes = null);
        bool CheckIfExists(Guid id);
        TModel GetEntityById(Guid id, List<String>? listOfIncludes);
    }

}
