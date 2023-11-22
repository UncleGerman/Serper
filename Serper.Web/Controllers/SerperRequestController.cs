using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Serper.API.Entity;
using Serper.API.Services;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/request")]
    public sealed class SerperRequestController : Controller
    {
        public SerperRequestController(ISerperRequestService serperRequestService)
        {
            _serperRequestService = serperRequestService 
                ?? throw new ArgumentNullException(nameof(serperRequestService));
        }

        private readonly ISerperRequestService _serperRequestService;

        [HttpPost]
        public async Task<IActionResult> SendReqestAsync(SearchParameters searchParameters)
        {
            if (searchParameters == null)
            {
                return StatusCode(400, "SearchParameters can not be null");
            }

            var response = await _serperRequestService.RequestToApiAsync(searchParameters);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var rootObject = JsonSerializer.Deserialize<RootObject>(response.Content);

                return StatusCode(200, rootObject);
            }

            return StatusCode(
                Convert.ToInt32(response.StatusCode), 
                response.ErrorMessage);
        }
    }
}