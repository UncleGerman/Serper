using RestSharp;
using Serper.API.Entity;

namespace Serper.API.Services
{
    public interface ISerperRequestService
    {
        public RestResponse Request(SearchParameters request);

        public RootObject GetRootObject();
    }
}