using Core.Models.Response;
using System.Net;

namespace Core.Common.Concrete
{
    public class ServiceResult<T> : Result<T>
    {
        public List<GetFlowersInformationResponseDataModel> Flowers {  get; set; }
    }

    public class ServiceResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string? InternalMessage { get; set; }
        public string? UserMessage { get; set; }
    }
}
