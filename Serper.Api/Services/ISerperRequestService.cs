using RestSharp;
using Serper.API.Entity;

namespace Serper.API.Services
{
    public interface ISerperRequestService
    {
        public Task<RestResponse> RequestToApiAsync(SearchParameters searchParameters);
    }
}