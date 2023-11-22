using RestSharp;
using System.Net;
using System.Text.Json;
using Serper.API.Entity;
using Serper.API.Services;

namespace Serper.Tests.Serper.ResourceServer
{
    public class SerperRequestControllerIntegrationTests
    {
        private readonly SearchParameters _searchParameters = new()
        {
            q = "apple inc",
            autocorrect = true,
            gl = "us",
            hl = "un",
            page = 1,
            type = "search"
        };

        [Fact]
        public async Task SendReqestAsync_TaskDone_ReturnOK()
        {
            var serperRequestController = GetReqestController(HttpStatusCode.OK);

            var result = await serperRequestController.SendReqestAsync(_searchParameters);

            var objectResult = (ObjectResult)result;

            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task SendReqestAsync_PassNullObject_ReturnBadReqest()
        {
            var serperRequestController = GetReqestController(HttpStatusCode.BadRequest);

            var result = await serperRequestController.SendReqestAsync(null);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task SendReqestAsync_TaskFailed_ReturnReqestStatusCode()
        {
            var serperRequestController = GetReqestController(HttpStatusCode.BadRequest);

            var result = await serperRequestController.SendReqestAsync(_searchParameters);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #region Initialized SerperRequestController

        private SerperRequestController GetReqestController(HttpStatusCode httpStatusCode)
        {
            var resrResponse = GerRestResponse(httpStatusCode);

            var restClient = GetRestClient(resrResponse);

            var serperRequestService = new SerperRequestService(restClient);

            var serperRequestController = new SerperRequestController(serperRequestService);

            return serperRequestController;
        }

        private RestResponse GerRestResponse(HttpStatusCode httpStatusCode)
        {
            var response = new RestResponse
            {
                StatusCode = httpStatusCode,

                Content = GetJson(),

                ErrorMessage = ""
            };

            return response;
        }

        private string GetJson()
        {
            var rootObject = new RootObject
            {
                SearchParameters = _searchParameters,

                Organic = new List<Organic>()
            };

            var json = JsonSerializer.Serialize(rootObject);

            return json;
        }

        private static IRestClient GetRestClient(RestResponse restResponse)
        {
            var restClient = new Mock<IRestClient>();

            restClient
                .Setup(restClient => restClient.ExecuteAsync(
                    It.IsAny<RestRequest>(),
                    CancellationToken.None))
                .ReturnsAsync(restResponse);

            return restClient.Object;
        }

        #endregion

    }
}
