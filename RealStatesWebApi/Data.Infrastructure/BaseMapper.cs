using Models.Core;

namespace Data.Infrastructure
{
    public interface IBaseMapper<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDTO
    {
        TDto MapToDTO(TEntity source);
        TEntity MapToEntity(TDto source);
    }
}
