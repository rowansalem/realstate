using Newtonsoft.Json;
using System.Net;

namespace Models.Core
{

    public class DataListApiResult<T> : ApiResult<T> where T : BaseDTO
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<T> DataList { get; set; }

        public DataListApiResult(bool isSuccess, List<T> dataList, string? message = null) : base(isSuccess, message)
        {

            DataList = dataList;
        }
    }
}
