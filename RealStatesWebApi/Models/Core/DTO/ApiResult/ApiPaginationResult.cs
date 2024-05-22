using Newtonsoft.Json;

namespace Models.Core
{

    public class ApiPaginationResult<T> where T : BaseDTO
    {


        public bool IsSuccess { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }

        #region ctor
        public ApiPaginationResult(bool isSuccess, string message, int page, int pageSize, int totalCount, List<T> data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            Data = data;
        }
        #endregion

    }

}
