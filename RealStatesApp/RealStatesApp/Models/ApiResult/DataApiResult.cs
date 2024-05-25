using Newtonsoft.Json;
using System.Net;

namespace RealStatesApp.Models { 
    public class DataApiResult<T> : ApiResult<T> where T : BaseDTO
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        public DataApiResult(bool isSuccess, string? message = null, T data = null) : base(isSuccess, message)
        {

            Data = data;
        }
    }
}
