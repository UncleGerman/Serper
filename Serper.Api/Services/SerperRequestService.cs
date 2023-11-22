using RestSharp;
using System.Text.Json;
using Serper.API.Entity;

namespace Serper.API.Services
{
    internal sealed class SerperRequestService : ISerperRequestService
    {
        public RestResponse RequestToApi(SearchParameters request)
        {
            var url = RequestSettings.ServiceUrl + request.type.ToString();
            var client = new RestClient(url);

            var restRequest = new RestRequest("", Method.Post);

            restRequest.AddHeader("X-API-KEY", RequestSettings.ApiKey);
            restRequest.AddHeader("Content-Type", "application/json");

            var body = JsonSerializer.Serialize(request);

            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(restRequest);

            return response;
        }
    }
}