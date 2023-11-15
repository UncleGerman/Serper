using RestSharp;
using System.Text.Json;
using System.Runtime.CompilerServices;
using Serper.API.Entity;

namespace Serper.API.Services
{
    internal sealed class SerperRequestService : ISerperRequestService
    {
        private RootObject? _rootObject;

        public RestResponse Request(SearchParameters request)
        {
            var client = new RestClient(RequestSettings.ServiceUrl);
            var restRequest = new RestRequest("", Method.Post);

            restRequest.AddHeader("X-API-KEY", RequestSettings.ApiKey);
            restRequest.AddHeader("Content-Type", "application/json");

            var body = JsonSerializer.Serialize(request);

            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(restRequest);

            _rootObject = JsonSerializer.Deserialize<RootObject>(response.Content);

            return response;
        }

        public RootObject GetRootObject()
        {
            return _rootObject;
        }
    }
}