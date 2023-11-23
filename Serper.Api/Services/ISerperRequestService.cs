using RestSharp;
using Serper.API.Entity;

namespace Serper.API.Services
{
    public interface ISerperRequestService
    {
        public RestResponse RequestToApi(SearchParameters request);
    }
}