using RestSharp;
using System.Text;
using System.Text.Json;
using Serper.API.Entity;

namespace Serper.API.Services
{
    internal class SerperRequestService : ISerperRequestService
    {
        public SerperRequestService(IRestClient restClient)
        {
            _restClient = restClient 
                ?? throw new ArgumentNullException(nameof(restClient));
        }

        private readonly IRestClient _restClient;

        public async Task<RestResponse> RequestToApiAsync(SearchParameters searchParameters)
        {
            if (searchParameters is null)
            {
                throw new ArgumentNullException(nameof(searchParameters));
            }

            if (searchParameters.type == null)
            {
                throw new ArgumentNullException(nameof(searchParameters.type));
            }

            var url = GetUrl(searchParameters.type);

            var restRequest = new RestRequest(url, Method.Post);

            restRequest.AddHeader("X-API-KEY", RequestSettings.ApiKey);
            restRequest.AddHeader("Content-Type", "application/json");

            var body = JsonSerializer.Serialize(searchParameters);

            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await _restClient.ExecuteAsync(restRequest);

            return response;
        }

        private string GetUrl(string searchType)
        {
            var stringBuilder = new StringBuilder(searchType);

            stringBuilder.Append(RequestSettings.ServiceUrl);

            return stringBuilder.ToString();
        }
    }
}