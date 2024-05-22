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
    public abstract class BaseService<TModel, TDto> : IService<TModel, TDto> where TModel : BaseEntity where TDto : BaseDTO
    {
        protected readonly IRepository<TModel> _repository;
        protected readonly IBaseMapper<TModel, TDto> _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IRepository<TModel> repository, IBaseMapper<TModel, TDto> mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual TDto GetById(Guid id, List<string>? listOfIncludes = null)
        {
            TModel entity = GetEntityById(id, listOfIncludes);
            return _mapper.MapToDTO(entity);

        }
        public virtual TDto Create(TDto dto)
        {
            TModel mappedEntity = _mapper.MapToEntity(dto);
            var newEntity = _repository.Add(mappedEntity);
            var newMappedEntity = _mapper.MapToDTO(newEntity);
            return newMappedEntity;
        }
        public virtual void Update(Guid id, TDto dto)
        {
            bool isExist = CheckIfExists(id);
            if (!isExist)
            {
                throw new EntityNotFoundException("Entity with id" + id + " is not exists");
            }
            TModel UpdatedEntity = _mapper.MapToEntity(dto);
            _repository.Update(id, UpdatedEntity);
        }
        public virtual void Delete(Guid id)
        {
            TModel entity = GetEntityById(id, null);
            _repository.Delete(entity);
        }
        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
        public virtual IEnumerable<TDto> GetAll(Expression<Func<TModel, bool>>? criteria = null, List<string>? listOfIncludes = null)
        {
            QueryBuilder<TModel> query = QueryBuilder<TModel>.FilterQuery(criteria, listOfIncludes);
            IEnumerable<TModel> entities = _repository.GetAll(query);
            return entities.Select(x => _mapper.MapToDTO(x));
        }
        public virtual ApiPaginationResult<TDto> GetAllPaged(FilterModel<TDto> filterModel, List<string>? listOfIncludes = null)
        {
            QueryBuilder<TModel> pagedQuery = QueryBuilder<TModel>.PagedQuery(null, listOfIncludes,
                filterModel.PageNumber,
                filterModel.PageSize,
                filterModel.IsAscending,
                ExpressionHelper.GetPropertySelector<TModel>(filterModel.SortBy));
            IEnumerable<TDto> list = _repository.GetAll(pagedQuery).Select(x => _mapper.MapToDTO(x));


            QueryBuilder<TModel> countQuery = QueryBuilder<TModel>.FilterQuery();
            int total = _repository.GetCount(countQuery);
            ApiPaginationResult<TDto> result = new ApiPaginationResult<TDto>(true,
                string.Empty,
                filterModel.PageNumber,
                filterModel.PageSize,
                total,
                list.ToList()
                );
            return result;
        }
        public virtual bool CheckIfExists(Guid id)
        {
            QueryBuilder<TModel> query = QueryBuilder<TModel>.FilterQuery(x => x.Id == id);
            return _repository.Any(query);
        }
        public virtual TModel GetEntityById(Guid id, List<String>? listOfIncludes)
        {
            var existingEntity = _repository.GetById(id, listOfIncludes);
            if (existingEntity == null)
                throw new EntityNotFoundException(String.Format("Entity with id" + id + " is not exists"));
            return existingEntity;
        }
    }

}
