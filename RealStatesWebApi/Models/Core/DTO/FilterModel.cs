

using Models.Core;

namespace Models.DTO
{
    public class FilterModel<T> where T : BaseDTO
    {
        public T SearchObject { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
        public FilterModel()
        {
        }
    }
}
