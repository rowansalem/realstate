using Newtonsoft.Json;
using System.Net;

namespace Models.Core
{

    public class ApiResult<T> where T : BaseDTO
    {
        public bool IsSuccess { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Message { get; set; }


        #region ctor
        public ApiResult(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        #endregion

        #region factory methods

        public static ApiResult<T> Success()
        {
            return new ApiResult<T>(true, null);
        }
        public static ApiResult<T> Success(string message)
        {
            return new ApiResult<T>(true, message);
        }

        #region data api responce factory methods
        public static ApiResult<T> Success(T data)
        {
            return new DataApiResult<T>(true, null, data);
        }
        public static ApiResult<T> Success(T data, string message)
        {
            return new DataApiResult<T>(true, message, data);
        }
        #endregion

        #region data list api responce factory methods
        public static ApiResult<T> Success(List<T> dataList)
        {
            return new DataListApiResult<T>(true, dataList, null);
        }
        public static ApiResult<T> Success(List<T> dataList, string message)
        {
            return new DataListApiResult<T>(true, dataList, message);
        }
        #endregion
        public static ApiResult<T> Error()
        {
            return new ApiResult<T>(false, null);
        }

        public static ApiResult<T> Error(string message)
        {
            return new ApiResult<T>(false, message);
        }

        #endregion


    }

}
